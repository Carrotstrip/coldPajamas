using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject shopUI;
    public GameObject inventoryUI;
    private float timer;
    private bool timerRunning;
    private bool startSequence;
    private int num_screens;
    public PlayerInput player_input;
    public Camera main_camera;
    public Camera fp_camera;
    public Canvas main_UI;

    // show pro shop
    void OnX()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    // show inventory
    void OnB()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    int PlayerCount()
    {
        int count = 0;
        // while player isn't null, add to count
        while (PlayerInput.GetPlayerByIndex(count))
        {
            count += 1;
        }
        return count - 1;
    }

    void UpdateScreenSize()
    {
        int current_num_screens = PlayerCount();

        if (current_num_screens != num_screens)
        {
            num_screens = current_num_screens;
            // indices 1-4
            int index = player_input.playerIndex;
            if (num_screens == 1)
            {
                // set camera sizes to 1 and positions to 0,0
                main_camera.rect = new Rect(0f, 0f, 1f, 1f);
                fp_camera.rect = new Rect(0f, 0f, 1f, 1f);
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 1;
            }
            if (num_screens == 2)
            {
                main_camera.rect = new Rect(0f, (index - 1) * 0.5f, 1f, 0.5f);
                fp_camera.rect = new Rect(0f, (index - 1) * 0.5f, 1f, 0.5f);
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 0.5f;
            }
            if (num_screens >= 3)
            {
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 0.5f;
                if (index <= 2)
                {
                    main_camera.rect = new Rect((index - 1) * 0.5f, 0f, 0.5f, 0.5f);
                    fp_camera.rect = new Rect((index - 1) * 0.5f, 0f, 0.5f, 0.5f);
                }
                else
                {
                    main_camera.rect = new Rect((index - 3) * 0.5f, 0.5f, 0.5f, 0.5f);
                    fp_camera.rect = new Rect((index - 3) * 0.5f, 0.5f, 0.5f, 0.5f);
                }
            }
        }
    }

    void Update()
    {
        UpdateScreenSize();
        if (startSequence)
        {
            if (timerRunning)
            {
                timer += Time.deltaTime;
                if (timer >= 4.0f)
                {
                    startSequence = false;
                    ToastManager.setShowDuration(4.0f);
                    ToastManager.Toast("Press Y to get Fishin");
                    ToastManager.Toast("Press V to cast and B to reel in some dinner");
                    ToastManager.Toast("Visit my shop by pressing X");
                    ToastManager.Toast("For your inventory, go ahead and press the start button");
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
