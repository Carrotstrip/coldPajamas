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
    private int catchCounter = 0;

    Fish fishOnLine;
    //Fish fishOnLine = new Fish(0,"",.0f,.0f,0);
    public PlayerInput player_input;
    private Vector2 rightStickInput;
    public Inventory inventory;
    public PlayerToastManager ptm;
    public fishDisplay fD;

    Gradient gradient_test;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    public event Action<int> OnCatchFish;

    private Queue<float> reelQueue;

    private bool hasFished;
    private bool hasInventory;
    private int timer = 6*60;
    IDictionary<int, Fish> indexToFishDict = new Dictionary<int, Fish>() {
        {0, new Fish(0,"Minnow",200,1,.01f,.6f,1)},
        {1, new Fish(1,"Smallmouth Bass",250,1,.05f,.5f,2)},
        {2, new Fish(2,"Largemouth Bass",270,2,.35f,.9f,3)},
        {3, new Fish(3,"Lake Trout",300,3,.1f,.5f,4)},
        {4, new Fish(4,"White Bass",350,3,.1f,.45f,5)},
        {5, new Fish(5,"Carp",370,4,.35f,.9f,7)},
        {6, new Fish(6,"Yellow Carp",400,4,.35f,.9f,8)},
        {7, new Fish(7,"WhiteFish",425,4,.15f,.60f,10)},
        {8, new Fish(8,"Steelhead Trout",450,4,.15f,.70f,12)},
        {9, new Fish(9,"Sunfish",475,5,.2f,.70f,15)},
        {10, new Fish(10,"Walleye",475,6,.2f,.70f,20)},
        {11, new Fish(11,"Northern Pike",475,7,.2f,.6f,30)},
        {12, new Fish(12,"Muskelunge",500,10,.2f,.8f,40)},
        {13, new Fish(13,"Crappie",520,10,.3f,.9f,50)},
        {14, new Fish(14,"Brook Trout",550,10,.35f,.9f,75)},
        {15, new Fish(15,"Coho Salmon",600,12,.25f,.5f,100)},
        {16, new Fish(16,"Atlantic Salmon",700,15,.25f,.9f,500)},
        {17, new Fish(17,"Lake Sturgeon",500,15,.25f,.5f,1000)},
        {18, new Fish(18,"Shark",500,10,.25f,.5f,1000)},
    };


    void Start()
    {
        fishMap = GameObject.Find("Ocean").GetComponent<FishMap>();
        rb = GetComponent<Rigidbody>();
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
        hasFished = false;

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
        // setup the reelQueue with 0's
        reelQueue = new Queue<float>();
        for (int i = 0; i < 10; ++i){
            reelQueue.Enqueue(0);
        }
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
            ptm.Toast("Press A to cast,\n Reel in with the right stick");
            timer = 0;
        }
        if (hasFished && timer == 6*60){
            ptm.Toast("Press X for the inventory");
        }
        ++timer;
        if (cast && has_fish){
            reel(rightStickInput);
        }
    }

    void OnRightStick(InputValue input){
        rightStickInput = input.Get<Vector2>();
    }

    void reel(Vector2 input){
        float distFromPrev = Mathf.Sqrt(Mathf.Pow(input.x - lastStickLocation.x, 2)
                             + Mathf.Pow(input.y - lastStickLocation.y, 2));
        lastStickLocation = input;
        // Add dist to the the reel queue and take average to find a dampened speed
        reelQueue.Dequeue();
        reelQueue.Enqueue(distFromPrev);
        float average = 0;
        foreach (float dist in reelQueue)
            average += dist;
        average /= 10;

        reelingSlider.value = average;
        // Set speed slider to red if outside the limits of the fish
        if (reelingSlider.value <= fishOnLine.maxSpeedLimit && reelingSlider.value >= fishOnLine.minSpeedLimit)
            reelingSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.blue;
        else
            reelingSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;

        // Adjust catch counter based on current reel Speed
        if (average > fishOnLine.minSpeedLimit && average < fishOnLine.maxSpeedLimit){
            ++catchCounter;
            catchSlider.value = catchCounter;
            if (catchCounter >= fishOnLine.catchCap)
                CatchFish();
        } else {
            catchCounter -= fishOnLine.decrementStep;
            if (catchCounter <= 0){
                if (fishOnLine.species == "Shark"){
                    ptm.OverwriteToast("Damn, you nearly got 'im.");
                } else {
                    ptm.OverwriteToast("They got away\nTry turning the controller sideways to reel.");
                }
                endFish();
                return;
            }
            catchSlider.value = catchCounter;
        }
        catchSlider.gameObject.transform
            .Find("Fill Area").Find("Fill")
            .GetComponent<Image>().color = gradient_test.Evaluate((float)catchCounter/(float)fishOnLine.catchCap);
    }

    void CatchFish(){
        caught = true;
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        // if rodMultiplier is 100, check if there is a shark
        if (rodMultiplier == 100)
        {
            (int x, int y) = FindLocation();
            if (fishMap.shark_pos.x == x && fishMap.shark_pos.y == y){
                // catch the shark!
                ptm.OverwriteToast("You caught the shark and won the game!");
                GameManager.SomeoneWon();
                endFish();
            } else {
                ptm.OverwriteToast("Looks like the shark isn't here...");
                endFish();
            }
        } else {
            OnCatchFish(fishOnLine.value);
            endFish();
            ptm.OverwriteToast("You caught a " + fishOnLine.species + "!\n That's worth " + fishOnLine.value + " Representative Currency!");
            fD.sendFish(fishOnLine.index);
        }
    }
    void findFish(int fishCount, bool isShark){
        if (!isShark){
            if (inventory.rodMultiplier == 100){
                ptm.OverwriteToast("Looks like the shark isn't here...");
                endFish();
                return;
            } else if (fishCount == 0){
                ptm.OverwriteToast("Nothing's biting around here,\n I've set you up with minimap fish finder.");
                endFish();
                return;
            }
        }
        rod_clone.transform.Rotate(-40, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = Color.green;
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        int rodMinRange = 0;
        if (rodMultiplier == 5)
            rodMinRange = 1;
        else if (rodMultiplier == 13)
            rodMinRange = 6;
        int fishIndex = Random.Range(rodMinRange + baitMultiplier,rodMultiplier + baitMultiplier + 1);
        if (isShark){
            fishOnLine = indexToFishDict[18];
        } else {
            fishOnLine = indexToFishDict[fishIndex];
        }
        // Get the shark on the line.
        catchSlider.maxValue = fishOnLine.catchCap;
        catchCounter = fishOnLine.catchCap/2;
        catchSlider.value = catchCounter;
        has_fish = true;
    }

    void endFish(){
        hasFished = true;
        caught = false;
        has_fish = false;
        cast = false;
        catchSlider.value = 0;
        // I like the idea of fish being scared off
        // and decrementing number of fish even if they weren't caught
        (int x, int y) = FindLocation();
        int rodMultiplier = inventory.rodMultiplier;
        // if rodMultiplier is 100, this is a golden rod, so check if there is a shark
        if (rodMultiplier == 100 && fishMap.shark_pos.x == x && fishMap.shark_pos.y == y)
            fishMap.freeze_shark = false;
        fishMap.decrementFish(x, y);
        Destroy(rod_clone);
        panel.SetActive(false);
        player_input.SwitchCurrentActionMap("Player");
    }

    IEnumerator WaitForFish(){
        cast = true;
        bool has_shark = false;
        (int x, int y) = FindLocation();
        int fishCount = fishMap.getFishCount(x, y);
        // if goldenRod is equipped and we're on shark spot, freeze the shark
        int rodMultiplier = inventory.rodMultiplier;
        // if rodMultiplier is 100, this is a golden rod, so check if there is a shark
        if (rodMultiplier == 100 && fishMap.shark_pos.x == x && fishMap.shark_pos.y == y){
            fishMap.freeze_shark = true;
            has_shark = true;
        }
        //Set CatchSLider to center to match up with the starting value once fish is found
        catchSlider.maxValue = 2;
        catchSlider.value = 1;
        reelingSlider.value = 0;
        catchSlider.gameObject.transform
            .Find("Fill Area").Find("Fill")
            .GetComponent<Image>().color = gradient_test.Evaluate(1);
        // Rod Instantiation
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection.normalized * 4;
        rod_clone = Instantiate(rod, spawnPos, Quaternion.identity);
        rod_clone.transform.parent = transform;
        rod_clone.transform.LookAt(transform);
        rod_clone.transform.Rotate(-60, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = Color.red;
        // Casting Animation
        float elapsedTime = 0;
        float waitTime = 0.50f;
        float startRotate = -.50f;
        float stopRotate = -9.0f;
        while (elapsedTime < waitTime)
        {
            float rotateValue = Mathf.Lerp(startRotate, stopRotate, 1-(elapsedTime / waitTime));
            rod_clone.transform.Rotate(rotateValue, 0, 0, Space.Self);
            elapsedTime += Time.deltaTime;
        
            // Yield here
            yield return null;
        } 
        elapsedTime = 0;
        waitTime = 0.50f;
        startRotate = 9.50f;
        stopRotate = 0.50f;
        while (elapsedTime < waitTime)
        {
            float rotateValue = Mathf.Lerp(startRotate, stopRotate, 1-(elapsedTime / waitTime));
            rod_clone.transform.Rotate(rotateValue, 0, 0, Space.Self);
            elapsedTime += Time.deltaTime;
        
            // Yield here
            yield return null;
        } 
        // for (int i = 0; i < 30; ++i){
        //     rod_clone.transform.Rotate(3.0f, 0, 0, Space.Self);
        //     yield return new WaitForSeconds(.00000001f);
        // }
        // for (int i = 0; i < 25; ++i){
        //     rod_clone.transform.Rotate(-4, 0, 0, Space.Self);
        //     yield return new WaitForSeconds(.001f);
        // }
        // Wait for Fish for some number of seconds
        float num_seconds = Random.Range(2.0f, 4.0f);
        yield return new WaitForSeconds(num_seconds);
        rb.freezeRotation = true;
        findFish(fishCount, has_shark);
    }
    
    (int, int) FindLocation(){
        int x = (int)(transform.position.x + 375) / 75;
        int y = (int)(transform.position.z + 375) / 75;
        return (x,y);
    }
}
public class Fish {
    public int index;
    public string species;
    public int catchCap;
    public float minSpeedLimit;
    public float maxSpeedLimit;
    public int value;
    public int decrementStep;
    public Fish(int index, string species, int catchCap, int decrementStep, float minSpeed, float maxSpeed, int value ){
        this.index = index;
        this.species = species;
        this.catchCap = catchCap;
        this.decrementStep = decrementStep;
        this.minSpeedLimit = minSpeed;
        this.maxSpeedLimit = maxSpeed;
        this.value = value;
    }
}
