using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachScript : MonoBehaviour
{
    public PlayerController pc;
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll){
        GameObject obj = coll.gameObject;
        Debug.Log("Triggered");
        if(obj.tag == "Player"){
            pc.can_move = false;
            shopUI.SetActive(!shopUI.activeSelf);
        }
    }
}
