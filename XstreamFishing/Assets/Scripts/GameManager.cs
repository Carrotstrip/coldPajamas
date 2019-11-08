using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{ get; private set; }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 
    private float timer;
    private bool timerRunning;
    private bool startSequence;
    private GameObject player;
    Inventory inventory;

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
        if (winState)
        {
            winState = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown("q")) {
            winState = true;
        }

        if (inventory.numFish >= 9 && !winState)
        {
            ToastManager.setShowDuration(4.0f);
            ToastManager.OverwriteToast("Looks like you fished this lake dry Partner. Catch ya tomorrow.");
            // winState = true;
        }
        if (startSequence)
        {
            if (timerRunning)
            {
                timer += Time.deltaTime;
                if (timer >= 4.0f)
                {
                    //startupText.text = "";
                    startSequence = false;
                    ToastManager.setShowDuration(4.0f);
                    ToastManager.Toast("Press Y to get Fishin");
                    ToastManager.Toast("Press V to cast and B to reel in some dinner");
                    ToastManager.Toast("Visit my shop by pressing X");
                    ToastManager.Toast("For your inventory, go ahead and press the start buttone");
                }
            }
            if (!timerRunning && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetKeyDown(KeyCode.Z)))
            {
                timer = 0.0f;
                timerRunning = true;
                ToastManager.Toast("It's a nice day to be out fishing. Feel free to come on down to the pro shop for supplies. Heck I'll even throw in some free advice.");
            }
        }

    }
}
