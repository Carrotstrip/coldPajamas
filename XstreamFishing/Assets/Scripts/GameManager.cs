using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool winState;
    public GameObject player_prefab;
    private List<PlayerInput> players;
    private List<string> controllers;
    public static bool game_started;
    public RectTransform panelRectTransform;
    public GameObject JoinCamera;
    public GameObject JoinCanvas;
    public GameObject Minimap;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // after someone presses start, don't allow people to join and set can_move to true on all boats
    void Start()
    {
        winState = false;
        controllers = new List<string>();
        game_started = false;
    }


    // Update is called once per frame
    void Update()
    {
        // if join button was pressed and this isn't in our list of players, add it
        if (!game_started && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            bool join = true;
            for (int i = 0; i < controllers.Count; i++)
            {
                if (controllers[i] == Gamepad.current.name)
                    join = false;
            }
            if (join)
            {
                controllers.Add(Gamepad.current.name);
                PlayerInput.Instantiate(player_prefab, playerIndex: controllers.Count, pairWithDevice: Gamepad.current);
                if (controllers.Count >= 2)
                {
                    panelRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    panelRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    panelRectTransform.pivot = new Vector2(0.5f, 0.5f);
                    panelRectTransform.anchoredPosition = Vector3.zero;
                }
            }
            Debug.Log("Joining " + Gamepad.current.name);
        }
        if (!game_started && Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            if (controllers.Count == 3)
            {
                panelRectTransform.anchorMin = new Vector2(1f, 0f);
                panelRectTransform.anchorMax = new Vector2(1f, 0f);
                panelRectTransform.pivot = new Vector2(0.5f, 0.5f);
                panelRectTransform.anchoredPosition = new Vector3(-350f, 230f, 0);
                panelRectTransform.localScale = new Vector3(4.6f, 4.6f, 1f);
            }
            // once someone starts the game, remove join ui and camera and allow players to start toasting and moving
            game_started = true;
            JoinCamera.SetActive(false);
            JoinCanvas.SetActive(false);
            Minimap.SetActive(true);
        }

        if (winState)
        {
            winState = false;
            controllers.Clear();
            SceneManager.LoadScene("MainMenu");
        }
    }

    public static void SomeoneWon()
    {
        winState = true;
    }
}
