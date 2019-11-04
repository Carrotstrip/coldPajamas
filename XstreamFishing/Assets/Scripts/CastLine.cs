using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class CastLine : MonoBehaviour
{
    public GameObject rod;
    GameObject rod_clone;
    GameObject boat;
    bool has_fish;
    bool cast;
    public string controller;

    public event Action<int> OnCatchFish;

    void Start()
    {
        has_fish = false;
        cast = false;
        boat = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        bool crit;
        if (controller == "")
        {
            crit = Input.GetKeyDown(KeyCode.Z);
        }
        else
        {
            crit = Input.GetButtonDown(controller + "A");
        }
        if (crit)
        {
            if (!cast)
            {
                // if Z pressed, instantiate old rod in front of player, wait 3-7 seconds for fish
                rod_clone = Instantiate(rod, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 5f), new Quaternion(0, 90, 55, 1));
                rod_clone.transform.parent = transform.parent;
                cast = true;
                boat.GetComponent<PlayerController>().can_move = false;
                StartCoroutine(WaitForFish());
            }
            else
            {
                // if Z is pressed and there is fish, bring up lil fish message and destroy rod
                if (has_fish)
                {
                    has_fish = false;
                    // TODO: add to inventory
                    // Inventory inventory = gameObject.GetComponentInParent(typeof(Inventory)) as Inventory;
                    Inventory inventory = boat.GetComponent<Inventory>();
                    inventory.AddFish();
                    OnCatchFish(1);
                    if (inventory.numFish % 3 == 1)
                    {
                        ToastManager.OverwriteToast("You caught a small fish!");
                    }
                    else if (inventory.numFish % 3 == 2)
                    {
                        ToastManager.OverwriteToast("You caught a medium fish!");

                    }
                    else
                    {
                        ToastManager.OverwriteToast("You caught a Large fish!");
                    }
                    StartCoroutine(StopText());
                }
                // if Z is pressed again and there is no fish, destroy rod
                else
                {
                    has_fish = false;
                    ToastManager.OverwriteToast("Reeled in too fast!");
                    StartCoroutine(StopText());
                }
                Destroy(rod_clone);
                StopCoroutine(WaitForFish());
                StopCoroutine(WaitForFishFlee());
                cast = false;
                boat.GetComponent<PlayerController>().can_move = true;
            }
        }
        if (cast)
        {
            if (has_fish)
                rod_clone.transform.rotation = new Quaternion(0, 55, 55, 1);
            else
                rod_clone.transform.rotation = new Quaternion(0, 90, 55, 1);
        }
    }

    IEnumerator WaitForFish()
    {
        float num_seconds = Random.Range(3.0f, 7.0f);
        yield return new WaitForSeconds(num_seconds);
        has_fish = true;
        // if there has been a fish for 1-2 seconds, set to no fish
        StartCoroutine(WaitForFishFlee());
    }

    IEnumerator WaitForFishFlee()
    {
        float num_seconds = Random.Range(1.0f, 2.0f);
        yield return new WaitForSeconds(num_seconds);
        if (has_fish)
        {
            has_fish = false;
            cast = false;
            ToastManager.OverwriteToast("Reeled in too slow!");
            Destroy(rod_clone);
        }
    }

    IEnumerator StopText()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
