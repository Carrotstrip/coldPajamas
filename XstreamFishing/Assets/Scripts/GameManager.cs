using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text startupText;
    private float timer;
    private bool timerRunning;
    private bool startSequence;
    public GameObject player;
    public Inventory inventory;

    public bool winState;
    // Start is called before the first frame update
    void Start()
    {
        //startupText.text = "It's a nice day to be out fishing \nfeel free to come on down to the pro shop for supplies\nHeck I'll even throw in some free advice";
        timerRunning = false;
        startSequence = true;
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory>();
        ToastManager.setShowDuration(4.0f);
        winState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.numFish >= 3 && !winState){
            //startupText.text = "Looks like you fished this lake dry Partner \n Catch ya tomorrow";
            ToastManager.setShowDuration(4.0f);
            ToastManager.OverwriteToast("Looks like you fished this lake dry Partner \n Catch ya tomorrow");
            winState = true;
        } 
        if (startSequence){
            if (timerRunning){
                timer += Time.deltaTime;
                if (timer >= 4.0f){
                    //startupText.text = "";
                    startSequence = false;
                    ToastManager.setShowDuration(1.0f);
                    //ToastManager.Toast("Press Z to Cast");
                }
            }
            if (!timerRunning && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0 || Input.GetKeyDown(KeyCode.Z))){
                timer = 0.0f;
                timerRunning = true;
                ToastManager.Toast("It's a nice day to be out fishing \nfeel free to come on down to the pro shop for supplies\nHeck I'll even throw in some free advice");
            }
        }
        
    }
}
