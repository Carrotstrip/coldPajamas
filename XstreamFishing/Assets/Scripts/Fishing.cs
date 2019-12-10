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
    public Text actionText;
    public GameObject InventoryUI;
    public PlayerManager playerManager;

    private FishMap fishMap;
    bool has_fish;
    bool cast;
    bool caught;
    private IEnumerator coroutine;
    private string[] fishArr;
    private Vector2 lastStickLocation;
    private float catchCounter = 0;

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

    private bool hasInventory;
    private int timer = 6 * 60;

    public GameObject bobberPrefab;
    private GameObject bobber;
    private Vector3 BobberInWaterPosition;

    private float max = 0.0f;
    IDictionary<int, Fish> indexToFishDict = new Dictionary<int, Fish>() {
        {0, new Fish(0,"Minnow",80,0.5f,.01f,.4f,1)},
        {1, new Fish(1,"Smallmouth Bass",100,0.5f,.05f,.5f,2)},
        {2, new Fish(2,"Largemouth Bass",270,2,.35f,.9f,3)},
        {3, new Fish(3,"Lake Trout",300,3,.1f,.5f,4)},
        {4, new Fish(4,"White Bass",350,3,.1f,.45f,5)},
        {5, new Fish(5,"Carp",370,4,.35f,.9f,7)},
        {6, new Fish(6,"Yellow Carp",400,4,.30f,.9f,8)},
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

    Color paleGreen = new Color(119.0f, 221.0f, 119.0f, 255.0f);
    Color green = new Color(0.0f/256f, 152.0f/256f, 23.0f/256f, 255.0f/255f);
    Color red = new Color(161.0f/256f, 0.0f/256f, 12.0f/256f, 255.0f/255f);
    private LineRenderer line;

    void Start()
    {
        fishMap = GameObject.Find("Ocean").GetComponent<FishMap>();
        rb = GetComponent<Rigidbody>();
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;

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
        for (int i = 0; i < 10; ++i)
        {
            reelQueue.Enqueue(0);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (cast && has_fish)
        {
            reel(rightStickInput);
        }
        if (line != null && bobber != null && rod_clone != null){
            line.SetPosition(0, bobber.transform.position);
            line.SetPosition(1, rod_clone.gameObject.transform.Find("Sphere").gameObject.transform.position);
            line.material.color = new Color(0.0f, 0.0f,0.0f, 35.0f);
        }
    }
    void OnB(){
        if (cast)
        {
            endFish();
        }
    }
    void OnA()
    {
        // CAST
        // if player has no rod, just toast
        if (inventory.rodMultiplier == 0)
        {
            ptm.OverwriteToast("Woah partner, looks like you don't have a rod!\nHead on over to Jimbo's to pick up an old rod!");
        }
        else
        {
            ptm.Toast("Reel in with the right stick");
            coroutine = WaitForFish();
            StartCoroutine(coroutine);
            player_input.SwitchCurrentActionMap("Fishing");
            // show fishing panel, hide inventory and action text
            panel.SetActive(true);
            if (playerManager.inventory_on_screen)
            {
                playerManager.OnX();
            }
            actionText.text = "";
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
            average += dist;
        average /= 10;

        reelingSlider.value = average;
        // Set speed slider to red if outside the limits of the fish
        if (reelingSlider.value <= fishOnLine.maxSpeedLimit && reelingSlider.value >= fishOnLine.minSpeedLimit)
            reelingSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.blue;
        else
            reelingSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;

        // Adjust catch counter based on current reel Speed
        float progress = 0.0f;
        Vector3 finalPos = rod_clone.transform.position + (transform.forward * 6);
        // + (transform.up * 7) + (transform.right*2);
        if (average > fishOnLine.minSpeedLimit && average < fishOnLine.maxSpeedLimit)
        {
            ++catchCounter;
            catchSlider.value = catchCounter;
            progress = (float)catchCounter / (float)fishOnLine.catchCap;
            bobber.transform.position = Vector3.Lerp(BobberInWaterPosition, finalPos, progress);
            if (catchCounter >= fishOnLine.catchCap)
                CatchFish();
        }
        else
        {
            catchCounter -= fishOnLine.decrementStep;
            progress = (float)catchCounter / (float)fishOnLine.catchCap;
            bobber.transform.position = Vector3.Lerp(BobberInWaterPosition, finalPos, progress);
            if (catchCounter <= 0)
            {
                if (fishOnLine.species == "Shark")
                {
                    ptm.OverwriteToast("Damn, you nearly got 'im.");
                }
                else
                {
                    ptm.OverwriteToast("Shoot Partner looks like ya let that " + fishOnLine.species + " walk off with your lunch\nTry turning the controller sideways to reel.");
                }
                endFish();
                return;
            }
            catchSlider.value = catchCounter;
        }
        catchSlider.gameObject.transform
            .Find("Fill Area").Find("Fill")
            .GetComponent<Image>().color = gradient_test.Evaluate((float)catchCounter / (float)fishOnLine.catchCap);
    }

    void CatchFish()
    {
        // tell GameManager that this player has caught a fish
        if (!GameManager.fish_caught[playerManager.index - 1])
        {
            GameManager.fish_caught[playerManager.index - 1] = true;
            // check if everyone has caught a fish, and if so turn off GameManager's tutorial
            // (should be done in GameManager probably but I don't want to keep adding things in update and this doesn't run as frequently)
            bool all_caught = true;
            for (int i = 0; i < GameManager.numPlayers; i++)
            {
                all_caught = all_caught && GameManager.fish_caught[i];
            }
            if (all_caught)
            {
                GameManager.minimap_tutorial = false;
            }
        }

        caught = true;
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        // if rodMultiplier is 100, check if there is a shark
        if (rodMultiplier == 100) {
            (int x, int y) = FindLocation();
            if (fishMap.shark_pos.x == x && fishMap.shark_pos.y == y) {
                // catch the shark!
                ptm.OverwriteToast("You caught the shark and won the game!");
                GameManager.SomeoneWon(playerManager.index);
                endFish();
            }
            else {
                ptm.OverwriteToast("Looks like the shark isn't here...");
                endFish();
            }
        }
        else
        {
            if(OnCatchFish != null) {
                OnCatchFish(fishOnLine.value);
            }
            endFish();
            ptm.OverwriteToast("You caught a " + fishOnLine.species + "!\n That's worth " + fishOnLine.value + " Finjamins!");
            fD.sendFish(fishOnLine.index);
        }
    }
    void findFish(int fishCount, bool isShark)
    {
        if (!isShark)
        {
            if (inventory.rodMultiplier == 100)
            {
                ptm.OverwriteToast("Looks like the shark isn't here...");
                endFish();
                return;
            }
            else if (fishCount == 0)
            {
                ptm.OverwriteToast("Nothing's biting around here,\n I've set you up with minimap fish finder.");
                endFish();
                return;
            }
        }
        rod_clone.transform.Rotate(-30, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = green;
        /* (Hacky) Each rod creates a span that are randomly sampled to find the fish
        * RodMultiplier : the highest index that can be sampled
        * baitMultiplier : a Shifts the span by this value */
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        int rodMinRange = 0;
        if (rodMultiplier == 5)
            rodMinRange = 1;
        else if (rodMultiplier == 13)
            rodMinRange = 6;
        int fishIndex = Random.Range(rodMinRange + baitMultiplier, rodMultiplier + baitMultiplier + 1);
        if (isShark)
        {
            fishOnLine = indexToFishDict[18];
        }
        else {
            fishOnLine = indexToFishDict[fishIndex];
        }
        // Get the shark on the line.
        catchSlider.maxValue = fishOnLine.catchCap;
        catchCounter = fishOnLine.catchCap / 2;
        catchSlider.value = catchCounter;
        // Reel Slider horizontal bars activation and adjustment
        reelingSlider.gameObject.transform.Find("Max").gameObject.SetActive(true);
        reelingSlider.gameObject.transform.Find("Min").gameObject.SetActive(true);
        RectTransform rtMax = reelingSlider.gameObject.transform.Find("Max").GetComponent<RectTransform>();
        RectTransform rtMin = reelingSlider.gameObject.transform.Find("Min").GetComponent<RectTransform>();
        rtMax.anchoredPosition = new Vector3(0.0f, fishOnLine.maxSpeedLimit * 100);
        rtMin.anchoredPosition = new Vector3(0.0f, fishOnLine.minSpeedLimit * 100);
        rtMax.GetComponent<Renderer>().material.color = Color.red;
        rtMin.GetComponent<Renderer>().material.color = Color.red;
        
        BobberInWaterPosition = bobber.transform.position;
        has_fish = true;
    }

    void endFish()
    {
        Destroy(line);
        Destroy(bobber);
        caught = false;
        has_fish = false;
        cast = false;
        catchSlider.value = 0;
        // Decrementing number of fish even if they weren't caught
        (int x, int y) = FindLocation();
        int rodMultiplier = inventory.rodMultiplier;
        // if rodMultiplier is 100, this is a golden rod, so check if there is a shark
        if (rodMultiplier == 100 && fishMap.shark_pos.x == x && fishMap.shark_pos.y == y)
            fishMap.freeze_shark = false;
        fishMap.decrementFish(x, y);
        Destroy(rod_clone);
        panel.SetActive(false);
        player_input.SwitchCurrentActionMap("Player");
        actionText.text = "Cast: A\n Sail: Y";
        reelingSlider.gameObject.transform.Find("Max").gameObject.SetActive(false);
        reelingSlider.gameObject.transform.Find("Min").gameObject.SetActive(false);
    }

    IEnumerator WaitForFish()
    {
        cast = true;
        bool has_shark = false;
        (int x, int y) = FindLocation();
        int fishCount = fishMap.getFishCount(x, y);
        // if goldenRod is equipped and we're on shark spot, freeze the shark
        int rodMultiplier = inventory.rodMultiplier;
        // if rodMultiplier is 100, this is a golden rod, so check if there is a shark
        if (rodMultiplier == 100 && fishMap.shark_pos.x == x && fishMap.shark_pos.y == y) {
            fishMap.freeze_shark = true;
            has_shark = true;
        }
        // Set CatchSLider to center to match up with the starting value once fish is found
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
        rod_clone.transform.Rotate(-80, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = red;
        // Casting Animation
        float elapsedTime = 0;
        float waitTime = 0.60f;
        float startRotate = .50f;
        float stopRotate = 8.0f;
        while (elapsedTime < waitTime){
            float rotateValue = Mathf.Lerp(startRotate, stopRotate, (elapsedTime / waitTime));
            rod_clone.transform.Rotate(rotateValue, 0, 0, Space.Self);
            elapsedTime += Time.deltaTime;
            yield return null;
        } 
        rod_clone.gameObject.transform.Find("Bobber").gameObject.SetActive(false);
        // Set fishing line
        line = this.gameObject.AddComponent<LineRenderer>();
        line.SetWidth(0.02f, 0.02f);
        line.SetVertexCount(2);

        elapsedTime = 0;
        waitTime = 0.30f;
        startRotate = -12.50f;
        stopRotate = -0.50f;
        while (elapsedTime < waitTime){
            float rotateValue = Mathf.Lerp(startRotate, stopRotate, (elapsedTime / waitTime));
            rod_clone.transform.Rotate(rotateValue, 0, 0, Space.Self);
            elapsedTime += Time.deltaTime;
            yield return null;
        } 
        Vector3 bobberSpawnPosition = rod_clone.transform.position + (transform.forward * 6) + (transform.up * 7) + (transform.right*2);
        //Vector3 bobberSpawnPosition = rod_clone.gameObject.transform.Find("Sphere").transform.position;
        //bobberSpawnPosition[1] = bobberSpawnPosition[1] + 5;
        bobber = Instantiate(bobberPrefab, bobberSpawnPosition, Quaternion.identity) as GameObject;
        bobber.GetComponent<Rigidbody>().AddForce(transform.forward * 1500 + transform.right * 2);
        var bobberRenderer = bobber.GetComponent<Renderer>();
        bobberRenderer.material.SetColor("_Color", red);
        // Wait for Fish for some number of seconds
        float num_seconds = Random.Range(2.0f, 4.0f);
        yield return new WaitForSeconds(num_seconds);
        rb.freezeRotation = true;
        findFish(fishCount, has_shark);
    }

    (int, int) FindLocation()
    {
        int x = (int)(transform.position.x + 375) / 75;
        int y = (int)(transform.position.z + 375) / 75;
        return (x, y);
    }
}
public class Fish
{
    public int index;
    public string species;
    public int catchCap;
    public float minSpeedLimit;
    public float maxSpeedLimit;
    public int value;
    public float decrementStep;
    public Fish(int index, string species, int catchCap, float decrementStep, float minSpeed, float maxSpeed, int value)
    {
        this.index = index;
        this.species = species;
        this.catchCap = catchCap;
        this.decrementStep = decrementStep;
        this.minSpeedLimit = minSpeed;
        this.maxSpeedLimit = maxSpeed;
        this.value = value;
    }
}
