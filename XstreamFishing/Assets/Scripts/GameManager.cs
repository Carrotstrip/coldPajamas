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
    public static AudioClip sharkTune;
    public static int numPlayers = 0;
    public static int winningPlayer = -1;
    public static bool minimap_tutorial;
    public static List<bool> fish_caught;


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
        fish_caught = new List<bool>();
        game_started = false;
        minimap_tutorial = true;
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
                numPlayers += 1;
                controllers.Add(Gamepad.current);
                fish_caught.Add(false);
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
                panelRectTransform.anchoredPosition = new Vector3(-437f, 325f, 0);
                panelRectTransform.localScale = new Vector3(10f, 10f, 1f);
                // set opacity to 1
                var img = panelRectTransform.gameObject.GetComponent<RawImage>();
                var tempColor = img.color;
                tempColor.a = 1f;
                img.color = tempColor;
            }
            // once someone starts the game, remove join ui and camera and allow players to start toasting and moving
            game_started = true;
            JoinCamera.SetActive(false);
            JoinCanvas.SetActive(false);
            Minimap.SetActive(true);
            AudioManager.instance.PlayMusic(mainTheme);
        }

        if (winState || Input.GetKeyDown(KeyCode.E))
        {
            // wait a sec
            StartCoroutine(WaitToEndGame());
        }
    }

    public static void SomeoneHasGoldenrod()
    {
        AudioManager.instance.PlayMusic(sharkTune);
    }

    IEnumerator WaitToEndGame()
    {
        yield return new WaitForSeconds(5f);
        winState = false;
        numPlayers = controllers.Count;
        controllers.Clear();
        AudioManager.instance.PlayMusic(mainTheme);
        fish_caught.Clear();
        game_started = false;
        minimap_tutorial = true;
        SceneManager.LoadScene("EndCutscene");
    }

    public static void SomeoneWon(int winner)
    {
        winningPlayer = winner;
        winState = true;
    }
}
