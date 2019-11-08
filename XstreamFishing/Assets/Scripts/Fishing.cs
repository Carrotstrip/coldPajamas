﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.FirstPerson;

public class Fishing : MonoBehaviour
{ 
    public GameObject rod;
    private Rigidbody rb;
    GameObject rod_clone;
    public GameObject panel;
    public Slider reelingSlider;
    public Slider catchSlider;
    public Slider releaseSlider;
    public FishMap fishMap;

    private FirstPersonController fpc;
    bool has_fish;
    bool cast;
    bool caught;
    private IEnumerator coroutine;
    private string[] fishArr;
    private Vector2 lastStickLocation;
    private int releaseCap = 200;
    private int catchCap = 300;
    private int releaseCounter = 0;
    private int catchCounter = 0;
    private float maxSpeedLimit = .1f;
    private float minSpeedLimit = .01f;


    //public event Action<int> OnCatchFish;

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
        fpc = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

    }


    // Update is called once per frame
    void Update()
    { 
        if (!cast && Gamepad.current.buttonSouth.wasPressedThisFrame){
            // CAST
            fpc.enabled = false;
            panel.SetActive(true);
            coroutine = WaitForFish();
            StartCoroutine(coroutine);

        } else {
            if (has_fish) {
                reel();
            }

        }
        if (!cast && !has_fish && !caught && !fpc.enabled){
            fpc.enabled = true;
        }
         /*else if (cast && Gamepad.current.buttonEast.wasPressedThisFrame){

            // REEL
            if(has_fish){
                // Catch Fish
                CatchFish();
            } else {
                // Reel in too quickly
                //Debug.Log("Reeled in too fast");
                ToastManager.OverwriteToast("Reeled in too fast!");
                StopCoroutine(coroutine);
            }
            //Destroy(rod_clone);
            endFish();
        }*/
    }

    void reel(){
        Vector2 input = Gamepad.current.rightStick.ReadValue();
        float distFromPrev = Mathf.Sqrt(Mathf.Pow(input.x - lastStickLocation.x,2) + Mathf.Pow(input.y - lastStickLocation.y,2));
        //Debug.Log(distFromPrev);
        reelingSlider.value = distFromPrev;
        lastStickLocation = input;
        if (distFromPrev > minSpeedLimit && distFromPrev < maxSpeedLimit){
            Debug.Log(distFromPrev);
            ++catchCounter;
            releaseCounter = releaseCounter <= 0 ? 0: --releaseCounter;
            releaseSlider.value = releaseCounter;
            catchSlider.value = catchCounter;
            switch(catchCounter){
                case 50:
                case 75:
                case 100:
                case 150:
                case 180:
                    rod_clone.transform.Rotate(10,0,0,Space.Self);
                    break;
                default:
                    break;
            }
            if (catchCounter > catchCap)
                CatchFish();
        } else {
            ++releaseCounter;
            releaseSlider.value = releaseCounter;
            catchCounter = catchCounter <= 0 ? 0: catchCounter-2;
            catchSlider.value = catchCounter;
            switch(releaseCounter){
                case 30:
                case 80:
                    rod_clone.transform.Rotate(-10,0,0,Space.Self);
                    break;
                default:
                    break;
            }
            if (releaseCounter > releaseCap)
                endFish();
        }

    }
    void CatchFish(){
        caught = true;
        int rodMultiplier = 1;
        int baitMultiplier = 1;
        int fishIndex = Random.Range(0,18) % (2 * rodMultiplier * baitMultiplier);
        Debug.Log("You caught a " + fishArr[fishIndex]+"!");
        ToastManager.OverwriteToast("You caught a " + fishArr[fishIndex]+"!");
        endFish();
    }
    
    void endFish(){
        caught = false;
        has_fish = false;
        cast = false;
        catchSlider.value = 0;
        releaseSlider.value = 0;
        reelingSlider.value = 0;
        // I like the idea of fish being scared off
        // and decrementing number of fish even if they weren't caught
        int x = (int)(transform.position.x + 375)/75;
        int y = (int)(transform.position.y + 375)/75;
        fishMap.decrementFish(x,y);
        Destroy(rod_clone);
        panel.SetActive(false);
    }
    IEnumerator WaitForFish()
    {
        ToastManager.OverwriteToast("Reel in with the right joystick");
        cast = true;
        int x = (int)(transform.position.x + 375)/75;
        int y = (int)(transform.position.y + 375)/75;
        int fishCount = fishMap.getFishCount(x,y);
        releaseCounter = 0;
        catchCounter = 0;
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection.normalized*4;
        rod_clone = Instantiate(rod, spawnPos, Quaternion.identity);
        rod_clone.transform.parent = transform;
        rod_clone.transform.LookAt(transform);
        rod_clone.transform.Rotate(-40,0,0,Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = Color.red;
        for (int i = 0; i < 50; ++i){
            if (i < 25){
                rod_clone.transform.Rotate(1,0,0,Space.Self);
                yield return new WaitForSeconds(.00001f);
            } else {
                rod_clone.transform.Rotate(-1,0,0,Space.Self);
                yield return new WaitForSeconds(.01f);
            }
        }
        float num_seconds = Random.Range(2.0f, 4.0f);
        yield return new WaitForSeconds(num_seconds);
        rb.freezeRotation = true;
        Vector2 input = Gamepad.current.rightStick.ReadValue();
        if (fishCount == 0){
            ToastManager.OverwriteToast("Looks like nothing's biting around here");
            endFish();
        } else {
            has_fish = true;
            rod_clone.transform.Rotate(-40,0,0,Space.Self);
            rod_clone.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
    // IEnumerator WaitForFishFlee()
    // {
    //     //float num_seconds = Random.Range(1.0f, 2.0f);
    //     yield return new WaitForSeconds(0.5f);
    //     if (has_fish)
    //     {
    //         endFish();
    //         ToastManager.OverwriteToast("Reeled in too slow!");
    //         Destroy(rod_clone);
    //     }
    // }

    //     if (Input.GetKeyDown(KeyCode.Z))
    //     {
    //         if (!cast)
    //         {
    //             // if Z pressed, instantiate old rod in front of player, wait 3-7 seconds for fish
    //             rod_clone = Instantiate(rod, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 5f), new Quaternion(0, 90, 55, 1));
    //             rod_clone.transform.parent = transform.parent;
    //             cast = true;
    //             boat.GetComponent<PlayerController>().can_move = false;
    //             StartCoroutine(WaitForFish());
    //         }
    //         else
    //         {
    //             // if Z is pressed and there is fish, bring up lil fish message and destroy rod
    //             if (has_fish)
    //             {
    //                 has_fish = false;
    //                 // TODO: add to inventory
    //                 // Inventory inventory = gameObject.GetComponentInParent(typeof(Inventory)) as Inventory;
    //                 Inventory inventory = boat.GetComponent<Inventory>();
    //                 inventory.AddFish();
    //                 OnCatchFish(1);
    //             }
    //             // if Z is pressed again and there is no fish, destroy rod
    //             else {
    //                 has_fish = false;
    //                 ToastManager.OverwriteToast("Reeled in too fast!");
    //             }
    //             Destroy(rod_clone);
    //             StopCoroutine(WaitForFish());
    //             StopCoroutine(WaitForFishFlee());
    //             cast = false;
    //             boat.GetComponent<PlayerController>().can_move = true;
    //         }
    //     }
    //     if (cast)
    //     {
    //         if (has_fish)
    //             rod_clone.transform.rotation = new Quaternion(0, 55, 55, 1);
    //         else
    //             rod_clone.transform.rotation = new Quaternion(0, 90, 55, 1);
    //     }
    // }
