using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class FishingKey : MonoBehaviour
{
    public GameObject rod;
    private Rigidbody rb;
    GameObject rod_clone;
    public Inventory inventory;

    bool has_fish;
    bool cast;
    private IEnumerator coroutine;
    private string[] fishArr;


    public static event Action<int> OnCatchFish;

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
    }


    // Update is called once per frame
    void Update()
    {
        // if (!cast && Gamepad.current.buttonSouth.wasPressedThisFrame){
        if (!cast && Input.GetKeyDown("v"))
        {
            // CAST
            coroutine = WaitForFish();
            StartCoroutine(coroutine);

        }
        else if (cast && Input.GetKeyDown("b")/*Gamepad.current.buttonEast.wasPressedThisFrame*/)
        {
            // REEL
            if (has_fish)
            {
                // Catch Fish
                CatchFish();
            }
            else
            {
                // Reel in too quickly
                //Debug.Log("Reeled in too fast");
                ToastManager.OverwriteToast("Reeled in too fast!");
                StopCoroutine(coroutine);
            }
            //Destroy(rod_clone);
            endFish();
        }
    }

    void CatchFish()
    {
        has_fish = false;
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        int fishIndex = Random.Range(0, 18) % (2 * rodMultiplier * baitMultiplier);
        Debug.Log("You caught a " + fishArr[fishIndex] + "!");
        ToastManager.OverwriteToast("You caught a " + fishArr[fishIndex] + "!");
        if (OnCatchFish != null)
        {
            OnCatchFish(fishIndex + 1);
        }
    }

    void endFish()
    {
        Debug.Log("T");
        has_fish = false;
        cast = false;
        Destroy(rod_clone);
    }
    IEnumerator WaitForFish()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection.normalized * 4;
        //rod_clone = Instantiate(rod, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 5f), new Quaternion(0, 90, 55, 1));
        //rod_clone = Instantiate(rod, spawnPos, playerRotation);
        rod_clone = Instantiate(rod, spawnPos, Quaternion.identity);
        rod_clone.transform.parent = transform;
        rod_clone.transform.LookAt(transform);
        rod_clone.transform.Rotate(-40, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = Color.red;
        cast = true;
        //Gamepad.current.SetMotorSpeeds(1.0f, 1.0f);
        float num_seconds = Random.Range(2.0f, 4.0f);
        yield return new WaitForSeconds(num_seconds);
        has_fish = true;
        rod_clone.transform.Rotate(-40, 0, 0, Space.Self);
        rod_clone.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(0.75f);
        if (has_fish)
        {
            Debug.Log("Reeled in too slow");
            endFish();
            ToastManager.OverwriteToast("Reeled in too slow!");
        }
    }

}
