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
    // Start is called before the first frame update
    void Start()
    {
        startupText.text = "It's a nice day to be out fishing \nfeel free to come on down to the pro shop for supplies\nHeck I'll even throw in some free advice";
        timerRunning = false;
        startSequence = true;
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.numFish >= 3){
            startupText.text = "Looks like you fished this lake dry Partner \n Catch ya tomorrow";
        } 
        if (startSequence){
            if (timerRunning){
                timer += Time.deltaTime;
                if (timer >= 4.0f){
                    startupText.text = "";
                    startSequence = false;
                }
            }
            if (!timerRunning && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0 || Input.GetKeyDown(KeyCode.Z))){
                timer = 0.0f;
                timerRunning = true;
            }
        }
        
    }
}
