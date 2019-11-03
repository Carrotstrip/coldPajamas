using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class CastLine : MonoBehaviour
{
    public GameObject rod;
    public Text fish_text;
    GameObject rod_clone;
    GameObject boat;
    bool has_fish;
    bool cast;

    public event Action<int> OnCatchFish;

    void Start()
    {
        has_fish = false;
        cast = false;
        fish_text.text = "";
        boat = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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
                    if (inventory.numFish % 3 == 1){
                        Debug.Log("TEST");
                        //fish_text.text = "You caught a small fish!";
                        ToastManager.OverwriteToast("You caught a small fish!");
                    } else if (inventory.numFish % 3 == 2){
                        //fish_text.text = "You caught a medium fish!";
                        ToastManager.OverwriteToast("You caught a medium fish!");

                    } else {
                        //fish_text.text = "You caught a Big Ass fish!";
                        ToastManager.OverwriteToast("You caught a Large fish!");
                    }
                    StartCoroutine(StopText());
                }
                // if Z is pressed again and there is no fish, destroy rod
                else
                {
                    has_fish = false;
                    ToastManager.OverwriteToast("Reeled in too fast!");
                    //fish_text.text = "Reeled in too fast!";
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
            //fish_text.text = "Reeled in too slow!";
            ToastManager.OverwriteToast("Reeled in too slow!");
            Destroy(rod_clone);
        }
    }

    IEnumerator StopText()
    {
        yield return new WaitForSeconds(1.5f);
        fish_text.text = "";
    }
}
