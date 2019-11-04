using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;


public class SwitchMode : MonoBehaviour
{
    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;
    public string controller;
    ShipRocker sr;
    void Start()
    {
        sr = boat.GetComponent<ShipRocker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(controller + "Y")/*Gamepad.current.buttonNorth.wasPressedThisFrame*/)
        {
            if (boat.GetComponent<Rigidbody>().isKinematic)
            {
                boat.GetComponent<Rigidbody>().isKinematic = false;
                boat.GetComponent<PlayerController>().enabled = true;
                boatCamera.SetActive(true);
                player.SetActive(false);
                sr.enabled = true;
            }
            else
            {
                boat.GetComponent<Rigidbody>().isKinematic = true;
                boat.GetComponent<PlayerController>().enabled = false;
                boatCamera.SetActive(false);
                player.transform.position = playerStartPos.transform.position;
                player.SetActive(true);
                sr.enabled = false;
            }
        }
        // if (Input.GetKey("1")){
        //     boat.GetComponent<Rigidbody>().isKinematic = false;
        //     boat.GetComponent<PlayerController>().enabled = true;
        //     boatCamera.SetActive(true);
        //     player.SetActive(false);
        //     sr.enabled = true;
        // }
        // if (Input.GetKey("2")){
        //     boat.GetComponent<Rigidbody>().isKinematic = true;
        //     boat.GetComponent<PlayerController>().enabled = false;
        //     boatCamera.SetActive(false);
        //     player.transform.position = playerStartPos.transform.position;
        //     player.SetActive(true);
        //     sr.enabled = false;
        // }

    }
}
