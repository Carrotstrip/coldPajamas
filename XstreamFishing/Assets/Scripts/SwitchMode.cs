using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;
    ShipRocker sr;
    void Start()
    {
        sr = boat.GetComponent<ShipRocker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1")){
            boat.GetComponent<Rigidbody>().isKinematic = false;
            boat.GetComponent<PlayerController>().enabled = true;
            boatCamera.SetActive(true);
            player.SetActive(false);
            sr.enabled = true;
        }
        if (Input.GetKey("2")){
            boat.GetComponent<Rigidbody>().isKinematic = true;
            boat.GetComponent<PlayerController>().enabled = false;
            boatCamera.SetActive(false);
            player.transform.position = playerStartPos.transform.position;
            player.SetActive(true);
            sr.enabled = false;
            Debug.Log(playerStartPos.transform.position);
            Debug.Log(player.transform.position);
        }
        
    }
}
