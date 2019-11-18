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
    private bool startSequence;
    private int num_screens;
    public PlayerInput player_input;
    public Camera main_camera;
    public Camera fp_camera;
    public Canvas main_UI;
    public GameObject boat;
    private Material mat;
    public GameObject sphere;
    public PlayerToastManager ptm;

    public int timer;

    void Start()
    {
        // get minimap sphere material
        mat = sphere.GetComponent<MeshRenderer>().materials[0];
        timer = 0;


        // get index, and set position based on index
        int index = player_input.playerIndex;

        // on join, turn text the right color and change text
        Text player_join_text = GameObject.Find("PlayerJoinText" + index).GetComponent<Text>();
        player_join_text.text = "Player " + index + " joined!";
        if (index == 1)
        {
            boat.transform.position = new Vector3(-200f, 0f, 200f);
            mat.color = Color.blue;
            player_join_text.color = Color.blue;
        }
        if (index == 2)
        {
            boat.transform.position = new Vector3(200f, 0f, 200f);
            mat.color = Color.red;
            player_join_text.color = Color.red;
        }
        if (index == 3)
        {
            boat.transform.position = new Vector3(-200f, 0f, -200f);
            mat.color = Color.yellow;
            player_join_text.color = Color.yellow;
        }
        if (index == 4)
        {
            boat.transform.position = new Vector3(200f, 0f, -200f);
            mat.color = Color.green;
            player_join_text.color = Color.green;
        }
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
        ptm.Toast("It's a nice day to be out fishing. \n free to come on down to the island pro shop for supplies.\n Heck I'll even throw in some free advice.");
    }

    // show inventory
    void OnX()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        if (inventoryUI.activeSelf)
        {
            Debug.Log("switch to ui");
            //player_input.SwitchCurrentActionMap("UI");
        }
        else
        {
            Debug.Log("switch to player");
            //player_input.SwitchCurrentActionMap("Player");
        }
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
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 2;
            }
            if (num_screens == 2)
            {
                if (index == 1)
                {
                    main_camera.rect = new Rect(0f, 0.5f, 1f, 0.5f);
                    fp_camera.rect = new Rect(0f, 0.5f, 1f, 0.5f);
                }
                else
                {
                    main_camera.rect = new Rect(0f, 0f, 1f, 0.5f);
                    fp_camera.rect = new Rect(0f, 0f, 1f, 0.5f);
                }
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 1f;
            }
            if (num_screens >= 3)
            {
                main_UI.GetComponent<CanvasScaler>().scaleFactor = 1f;
                if (index <= 2)
                {
                    main_camera.rect = new Rect((index - 1) * 0.5f, 0.5f, 0.5f, 0.5f);
                    fp_camera.rect = new Rect((index - 1) * 0.5f, 0.5f, 0.5f, 0.5f);
                }
                else
                {
                    main_camera.rect = new Rect((index - 3) * 0.5f, 0f, 0.5f, 0.5f);
                    fp_camera.rect = new Rect((index - 3) * 0.5f, 0f, 0.5f, 0.5f);
                }
            }
        }
    }

    void Update()
    {
        UpdateScreenSize();
        if (timer >= 45 * 60)
        {
            ptm.Toast("I've been hearing about a SHARK thats eating all the fish in the lake.\n It sure would be wonderful for someone get out there \n and catch it with the GOLDEN ROD.");
            timer = 0;
        }
        ++timer;
    }
}
