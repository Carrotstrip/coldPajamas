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
    public Inventory inventory;

    bool has_fish;
    bool cast;
    private IEnumerator coroutine;
    private string[] fishArr;
    public string controller;


    public event Action<int> OnCatchFish;

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
        bool player_reel;
        bool player_cast;
        if (controller == "")
        {
            player_cast = Input.GetKeyDown("v");
            player_reel = Input.GetKeyDown("b");
        }
        else
        {
            player_cast = Input.GetButtonDown(controller + "A");
            player_reel = Input.GetButtonDown(controller + "B");
        }
        // if (!cast && Gamepad.current.buttonSouth.wasPressedThisFrame){
        if (!cast && player_cast)
        {
            // CAST
            coroutine = WaitForFish();
            StartCoroutine(coroutine);

        }
        else if (cast && player_reel)
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
                if (controller == "")
                    ToastManager.OverwriteToast("Reeled in too fast!");
                StopCoroutine(coroutine);
            }
            //Destroy(rod_clone);
            endFish();
        }
    }

    void CatchFish()
    {
        int rodMultiplier = inventory.rodMultiplier;
        int baitMultiplier = inventory.baitMultiplier;
        int fishIndex = Random.Range(0, 18) % (2 * rodMultiplier * baitMultiplier);
        Debug.Log("You caught a " + fishArr[fishIndex] + "!");
        if (controller == "")
            ToastManager.OverwriteToast("You caught a " + fishArr[fishIndex] + "!");
        if (OnCatchFish != null)
        {
            OnCatchFish(fishIndex + 1);
        }
    }

    void endFish()
    {
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
            if (controller == "")
                ToastManager.OverwriteToast("Reeled in too slow!");
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
