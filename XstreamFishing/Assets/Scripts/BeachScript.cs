using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BeachScript : MonoBehaviour
{
    public PlayerInput player_input;

    public PlayerController pc;
    public GameObject shopUI;
    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Player"){
            shopUI.SetActive(!shopUI.activeSelf);
        }
    }
}
