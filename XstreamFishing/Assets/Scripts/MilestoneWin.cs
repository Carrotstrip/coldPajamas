using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MilestoneWin : MonoBehaviour
{

	public Inventory player1, player2, player3, player4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	Debug.Log(Input.GetButton("JB"));
        if(player1.numFish == 10){
        	StartCoroutine(Win("Player 1"));
        }
        else if(player2.numFish == 10){
        	StartCoroutine(Win("Player 2"));
        }
        else if(player3.numFish == 10){
        	StartCoroutine(Win("Player 3"));
        }
        else if(player4.numFish == 10){
        	StartCoroutine(Win("Player 4"));
        }
    }

    IEnumerator Win(string player){
    	ToastManager.Toast(player + " Wins!");
    	yield return new WaitForSeconds(5f);
    	SceneManager.LoadScene("MainMenu");
    }
}
