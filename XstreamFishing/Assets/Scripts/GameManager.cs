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
    private List<Gamepad> controllers;
    public static bool game_started;
    public RectTransform panelRectTransform;
    public GameObject JoinCamera;
    public GameObject JoinCanvas;
    public GameObject Minimap;
    public AudioClip mainTheme;


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
        //UnityEditor.PlayerSettings.SetAspectRatio(UnityEditor.Enumerations.AspectRatio.Aspect5by4, true);
        Screen.SetResolution((int)(Screen.height * (5f / 4f)), Screen.height, true);
        winState = false;
        AudioManager.instance.PlayMusic(mainTheme);
        controllers = new List<Gamepad>();
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
                if (controllers[i] == Gamepad.current)
                    join = false;
            }
            if (join)
            {
                controllers.Add(Gamepad.current);
                PlayerInput.Instantiate(player_prefab, playerIndex: controllers.Count, pairWithDevice: Gamepad.current);
                if (controllers.Count >= 2)
                {
                    panelRectTransform.anchorMin = new Vector2(0f, 0.5f);
                    panelRectTransform.anchorMax = new Vector2(0f, 0.5f);
                    panelRectTransform.pivot = new Vector2(0.5f, 0.5f);
                    panelRectTransform.anchoredPosition = new Vector3(200f, 0, 0);
                }
            }
            Debug.Log("Joining " + Gamepad.current.name);
        }
        if (!game_started && controllers.Count > 0 && Gamepad.current.startButton.wasPressedThisFrame)
        {
            if (controllers.Count == 3)
            {
                panelRectTransform.anchorMin = new Vector2(1f, 0f);
                panelRectTransform.anchorMax = new Vector2(1f, 0f);
                panelRectTransform.pivot = new Vector2(0.5f, 0.5f);
                panelRectTransform.anchoredPosition = new Vector3(-250f, 200f, 0);
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
            // wait a sec
            StartCoroutine(WaitToEndGame());
        }
    }

    IEnumerator WaitToEndGame()
    {
        yield return new WaitForSeconds(5f);
        winState = false;
        controllers.Clear();
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public static void SomeoneWon()
    {
        winState = true;
    }
}
