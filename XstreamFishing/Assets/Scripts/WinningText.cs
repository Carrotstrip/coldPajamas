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
        t.text = "Player " + GameManager.winningPlayer + " caught the shark!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
