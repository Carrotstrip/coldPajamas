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
    public Slider releaseSlider;
    private FishMap fishMap;
    bool has_fish;
    bool cast;
    bool caught;
    private IEnumerator coroutine;
    private string[] fishArr;
    private Vector2 lastStickLocation;
    private int releaseCap = 300;
    private int catchCap = 100;
    private int releaseCounter = 0;
    private int catchCounter = 0;
    private float maxSpeedLimit = .5f;
    private float minSpeedLimit = .25f;
    public PlayerInput player_input;
    private Vector2 rightStickInput;
    public Inventory inventory;
    public PlayerToastManager ptm;

    public event Action<int> OnCatchFish;

    private Queue<float> reelQueue;

    private bool hasFished;
    private bool hasInventory;
    private int timer = 6*60;
    void Start()
    {
        endFish();
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
        rb = GetComponent<Rigidbody>();
        catchSlider.maxValue = catchCap;
        releaseSlider.maxValue = releaseCap;
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

        if (average > minSpeedLimit && average < maxSpeedLimit)
        {
            ++catchCounter;
            releaseCounter = releaseCounter <= 0 ? 0 : --releaseCounter;
            releaseSlider.value = releaseCounter;
            catchSlider.value = catchCounter;
            // switch (catchCounter)
            // {
            //     case 50:
            //     case 75:
            //     case 100:
            //     case 150:
            //     case 180:
            //         rod_clone.transform.Rotate(10, 0, 0, Space.Self);
            //         break;
            //     default:
            //         break;
            // }
            if (catchCounter > catchCap)
                CatchFish();
        }
        else
        {
            ++releaseCounter;
            releaseSlider.value = releaseCounter;
            catchCounter = catchCounter <= 0 ? 0 : catchCounter - 2;
            catchSlider.value = catchCounter;
            switch (releaseCounter)
            {
                case 30:
                case 80:
                    ptm.OverwriteToast("Use the right stick to reel.");
                    //rod_clone.transform.Rotate(-10, 0, 0, Space.Self);
                    break;
                default:
                    break;
            }
            if (releaseCounter > releaseCap)
                endFish();
        }
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
            OnCatchFish(fishIndex + 1);
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
        releaseSlider.value = 0;
        reelingSlider.value = 0;
        // I like the idea of fish being scared off
        // and decrementing number of fish even if they weren't caught
        int x = (int)(transform.position.x + 375) / 75;
        int y = (int)(transform.position.z + 375) / 75;
        fishMap = GameObject.Find("Ocean").GetComponent<FishMap>();
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
        releaseCounter = 0;
        catchCounter = 0;
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
