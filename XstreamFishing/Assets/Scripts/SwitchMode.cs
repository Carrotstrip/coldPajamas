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
    private bool hasSwitched;
    public PlayerToastManager ptm;
    private int timer = 6*60;

    void Start(){
        hasSwitched = false;
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
    }

    void Update(){
        if(!hasSwitched && timer >= 6*60){
            ptm.Toast("Press Y to get Fishin");
            timer = 0;
        }
        ++timer;
        
    }
    // Update is called once per frame
    void OnY()
    {
        hasSwitched = true;
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
