using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SwitchMode : MonoBehaviour
{
    public GameObject boat;
    public GameObject boatCamera;
    public Camera actualBoatCamera;
    public Camera mainCamera;
    public Canvas canvas;
    public GameObject player;
    public GameObject playerStartPos;
    public ShipRocker sr;

    // Update is called once per frame
    void OnY()
    {
        if (boat.GetComponent<Rigidbody>().isKinematic)
        {
            boat.GetComponent<Rigidbody>().isKinematic = false;
            boat.GetComponent<PlayerController>().enabled = true;
            boatCamera.SetActive(true);
            canvas.worldCamera = mainCamera;
            player.SetActive(false);
            sr.enabled = true;
        }
        else
        {
            boat.GetComponent<Rigidbody>().isKinematic = true;
            boat.GetComponent<PlayerController>().enabled = false;
            boatCamera.SetActive(false);
            canvas.worldCamera = actualBoatCamera;
            //Vector3 x = new Vector3(playerStartPos.transform.position.x, playerStartPos.transform.position.y + 100, playerStartPos.transform.position.z);
            player.transform.position = playerStartPos.transform.position;
            player.SetActive(true);
            sr.enabled = false;
        }
    }
}
