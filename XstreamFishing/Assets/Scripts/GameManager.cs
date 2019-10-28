using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text startupText;
    private float timer;
    private bool timerRunning;
    // Start is called before the first frame update
    void Start()
    {
        startupText.text = "It's a nice day to be out fishing, \nfeel free to come on down to the pro shop for supplies\nHeck I'll even throw in some free advice";
        timerRunning = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning){
            timer += Time.deltaTime;
            if (timer >= 4.0f){
                startupText.text = "";
            }
            if (timer >= 10.0f){
                startupText.text = "";
            }

        }
        if (!timerRunning && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)){
            timer = 0.0f;
            timerRunning = true;
        }
        
    }
}
