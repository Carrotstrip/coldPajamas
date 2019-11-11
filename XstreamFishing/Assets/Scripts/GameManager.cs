﻿using System.Collections;
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
    private bool start_mode;
    public RectTransform panelRectTransform;


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
        start_mode = true;
    }


    // Update is called once per frame
    void Update()
    {
        // if join button was pressed and this isn't in our list of players, add it
        if (start_mode && Gamepad.current.buttonSouth.wasPressedThisFrame)
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
        if (start_mode && Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            start_mode = false;
        }

        if (winState)
        {
            winState = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public static void SomeoneWon()
    {
        winState = true;
    }
}
