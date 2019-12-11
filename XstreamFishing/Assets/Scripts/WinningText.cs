using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinningText : MonoBehaviour
{
	private Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        t.text = "I've been trying to catch that beast for 50 years... \nI don't know how to thank you Player " 
                  + GameManager.winningPlayer + ". \nHow about I make you some of my famous cannoli?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
