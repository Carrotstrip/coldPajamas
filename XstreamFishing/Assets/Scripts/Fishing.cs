using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Fishing : MonoBehaviour
{
    public GameObject rod;
    private Rigidbody rb;
    GameObject rod_clone;
    public GameObject panel;
    public Slider reelingSlider;
    public Slider catchSlider;
    private FishMap fishMap;
    bool has_fish;
    bool cast;
    bool caught;
    private IEnumerator coroutine;
    private string[] fishArr;
    private Vector2 lastStickLocation;
    private int releaseCap = 300;
    private int catchCap = 400;
    private int releaseCounter = 0;
    private int catchCounter = 0;
    private float maxSpeedLimit = .5f;
    private float minSpeedLimit = .01f;
    public PlayerInput player_input;
    private Vector2 rightStickInput;
    public Inventory inventory;
    public PlayerToastManager ptm;

    Gradient gradient_test;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    public event Action<int> OnCatchFish;

    private Queue<float> reelQueue;

    private bool hasFished;
    private bool hasInventory;
    private int timer = 6*60;
    IDictionary<int, int> fishToValueDict = new Dictionary<int, int>() {
        {0, 1},
        {1, 2},
        {2, 3},
        {3, 4},
        {4, 5},
        {5, 7},
        {6, 8},
        {7, 10},
        {8, 12},
        {9, 15},
        {10, 20},
        {11, 30},
        {12, 40},
        {13, 50},
        {14, 75},
        {15, 100},
        {16, 500},
        {17, 1000}
    };
    IDictionary<int, Fish> indexToFishDict = new Dictionary<int, Fish>() {
        {0, new Fish(0,"minnow",200,.01f,.6f,1)},
        {1, new Fish(1,"Smallmouth Bass",250,.05f,.5f,2)},
        {2, new Fish(2,"Largemouth Bass",250,.05f,.5f,3)},
        {3, new Fish(3,"Lake Trout",250,.05f,.5f,4)},
        {4, new Fish(4,"White Bass",250,.05f,.5f,5)},
        {5, new Fish(5,"Carp",250,.05f,.5f,7)},
        {6, new Fish(6,"Yellow Carp",250,.05f,.5f,8)},
        {7, new Fish(7,"WhiteFish",250,.05f,.5f,10)},
        {8, new Fish(8,"Steelhead Trout",250,.05f,.5f,12)},
        {9, new Fish(9,"Sunfish",250,.05f,.5f,15)},
        {10, new Fish(10,"Walleye",250,.05f,.5f,20)},
        {11, new Fish(11,"Northern Pike",250,.05f,.5f,30)},
        {12, new Fish(12,"Muskelunge",250,.05f,.5f,40)},
        {13, new Fish(13,"Crappie",250,.05f,.5f,50)},
        {14, new Fish(14,"Brook Trout",250,.05f,.5f,75)},
        {15, new Fish(15,"Coho Salmon",250,.05f,.5f,100)},
        {16, new Fish(16,"Atlantic Salmon",250,.05f,.5f,500)},
        {17, new Fish(17,"Lake Sturgeon",250,.05f,.5f,1000)},
    };

    void Start()
    {
        fishMap = GameObject.Find("Ocean").GetComponent<FishMap>();
        //endFish();
        fishArr = new string[18]{
            "Minnow",
            "Smallmouth Bass",
            "Largemouth Bass",
            "Lake Trout",
            "White Bass",
            "Carp",
            "Yellow Perch",
            "Whitefish",
            "Steelhead Trout",
            "Sunfish",
            "Walleye",
            "Muskelunge",
            "Northern Pike",
            "Crappie",
            "Brook Trout",
            "Coho Salmon ",
            "Atlantic Salmon",
            "Lake Sturgeon"
        };


        gradient_test = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[3];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.3f;
        colorKey[1].color = new Color(255f / 256f, 255f / 256f, 0f / 256f, 1);
        colorKey[1].time = 0.5f;
        colorKey[2].color = new Color(0f / 256f, 128f / 256f, 0f / 256f, 1);
        colorKey[2].time = 0.7f;
        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[3];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.3f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.5f;
        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time = 0.7f;

        gradient_test.SetKeys(colorKey, alphaKey);

        rb = GetComponent<Rigidbody>();
        catchSlider.maxValue = catchCap;
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
        reelQueue = new Queue<float>();
        for (int i = 0; i < 5; ++i)
        {
            reelQueue.Enqueue(0);
        }
        hasFished = false;
    }

    void OnA()
    {
        // CAST
        panel.SetActive(true);
        coroutine = WaitForFish();
        StartCoroutine(coroutine);
        player_input.SwitchCurrentActionMap("Fishing");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!hasFished && timer >= 6*60){
            ptm.Toast("Press A to cast and reel in with the right stick");
            timer = 0;
        }
        if (hasFished && timer == 6*60){
            ptm.Toast("Press X for the inventory");
        }
        ++timer;
        if (cast && has_fish)
        {
            // Debug.Log(player_input.currentActionMap.name);
            // Debug.Log(rightStickInput);
            reel(rightStickInput);
        }
    }

    void OnRightStick(InputValue input)
    {
        rightStickInput = input.Get<Vector2>();
    }

    void reel(Vector2 input)
    {
        float distFromPrev = Mathf.Sqrt(Mathf.Pow(input.x - lastStickLocation.x, 2)
                             + Mathf.Pow(input.y - lastStickLocation.y, 2));
        lastStickLocation = input;
        // Add dist to the the reel queue and take average to find a dampened speed
        reelQueue.Dequeue();
        reelQueue.Enqueue(distFromPrev);
        float average = 0;
        foreach (float dist in reelQueue)
        {
            average += dist;
        }
        average /= 5;

        reelingSlider.value = average;
        // Set speed slider to red if outside the limits of the fish
        if (reelingSlider.value <= maxSpeedLimit && reelingSlider.value >= minSpeedLimit)
            reelingSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.blue;
        else
            reelingSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;

        if (average > minSpeedLimit && average < maxSpeedLimit)
        {
            ++catchCounter;
            catchSlider.value = catchCounter;
            if (catchCounter >= catchCap)
                CatchFish();
        }
        else
        {
            --catchCounter;
            catchSlider.value = catchCounter;
            if (catchCounter == 0)
                endFish();
        }
        catchSlider.gameObject.transform
            .Find("Fill Area").Find("Fill")
            .GetComponent<Image>().color = gradient_test.Evaluate((float)catchCounter/(float)catchCap);
    }

    void CatchFish()
    {
        caught = true;
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        int fishIndex = Random.Range(0, 18) % (2 * rodMultiplier * baitMultiplier);
        // if rodMultiplier is 100, check if there is a shark
        if (rodMultiplier == 100)
        {
            int x = (int)(transform.position.x + 375) / 75;
            int y = (int)(transform.position.z + 375) / 75;
            if (fishMap.shark_pos.x == x && fishMap.shark_pos.y == y)
            {
                // catch the shark!
                ptm.OverwriteToast("You caught the shark and won the game!");
                GameManager.SomeoneWon();
                endFish();
            }
            else
            {
                ptm.OverwriteToast("Looks like the shark isn't here...");
                endFish();
            }
        }
        else
        {
            Debug.Log("fish index " + fishIndex);
            OnCatchFish(fishToValueDict[fishIndex]);
            endFish();
            ptm.OverwriteToast("You caught a " + fishArr[fishIndex] + "!");
        }
    }

    void endFish()
    {
        hasFished = true;
        caught = false;
        has_fish = false;
        cast = false;
        catchSlider.value = 0;
        // I like the idea of fish being scared off
        // and decrementing number of fish even if they weren't caught
        int x = (int)(transform.position.x + 375) / 75;
        int y = (int)(transform.position.z + 375) / 75;

        int rodMultiplier = inventory.rodMultiplier;
        // if rodMultiplier is 100, this is a golden rod, so check if there is a shark
        if (rodMultiplier == 100 && fishMap.shark_pos.x == x && fishMap.shark_pos.y == y)
        {
            fishMap.freeze_shark = false;
        }
        fishMap.decrementFish(x, y);
        Destroy(rod_clone);
        panel.SetActive(false);
        player_input.SwitchCurrentActionMap("Player");
    }

    IEnumerator WaitForFish()
    {
        // ToastManager.OverwriteToast("Reel in with the right joystick");
        cast = true;
        bool has_shark = false;
        int x = (int)(transform.position.x + 375) / 75;
        int y = (int)(transform.position.z + 375) / 75;
        int fishCount = fishMap.getFishCount(x, y);
        // if goldenRod is equipped and we're on shark spot, freeze the shark
        int rodMultiplier = inventory.rodMultiplier;
        // if rodMultiplier is 100, this is a golden rod, so check if there is a shark
        if (rodMultiplier == 100 && fishMap.shark_pos.x == x && fishMap.shark_pos.y == y)
        {
            fishMap.freeze_shark = true;
            has_shark = true;
        }
        catchCounter = catchCap/2;
        catchSlider.value = catchCounter;
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection.normalized * 4;
        rod_clone = Instantiate(rod, spawnPos, Quaternion.identity);
        rod_clone.transform.parent = transform;
        rod_clone.transform.LookAt(transform);
        rod_clone.transform.Rotate(-40, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = Color.red;
        for (int i = 0; i < 30; ++i)
        {
            rod_clone.transform.Rotate(3.0f, 0, 0, Space.Self);
            yield return new WaitForSeconds(.00000001f);
        }
        for (int i = 0; i < 25; ++i)
        {
            rod_clone.transform.Rotate(-4, 0, 0, Space.Self);
            yield return new WaitForSeconds(.001f);
        }
        float num_seconds = Random.Range(2.0f, 4.0f);
        yield return new WaitForSeconds(num_seconds);
        rb.freezeRotation = true;
        if (fishCount == 0 && !has_shark)
        {
            ptm.OverwriteToast("Looks like nothing's biting around here");
            endFish();
        }
        else
        {
            has_fish = true;
            rod_clone.transform.Rotate(-40, 0, 0, Space.Self);
            rod_clone.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
public class Fish {
    int index;
    string species;
    int catchCap;
    float minSpeed;
    float maxSpeed;
    int value;
    public Fish(int index, string species, int catchCap, float minSpeed, float maxSpeed, int value){
        this.index = index;
        this.species = species;
        this.catchCap = catchCap;
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.value = value;
    }
}
