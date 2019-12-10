using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VictorySceneManager : MonoBehaviour
{

	public GameObject p1, p2, p3, p4;
	public GameObject t;
	public GameObject s;
	private int numPlayers = 3;
	private bool waited = false;
	private GameObject winningBoat;
	private Vector3 trav;
    // Start is called before the first frame update
    void Start()
    {
    	s.SetActive(false);
    	t.SetActive(false);
        if(GameManager.numPlayers == 1){
        	p1.transform.position = new Vector3(p1.transform.position.x + 22.5f, p1.transform.position.y, p1.transform.position.z);
        	p2.SetActive(false);
        	p3.SetActive(false);
        	p4.SetActive(false);
        }
        else if(GameManager.numPlayers == 2){
        	p1.transform.position = new Vector3(p1.transform.position.x + 15f, p1.transform.position.y, p1.transform.position.z);
        	p2.transform.position = new Vector3(p2.transform.position.x + 15f, p2.transform.position.y, p2.transform.position.z);
        	p3.SetActive(false);
        	p4.SetActive(false);
        }
        else if(GameManager.numPlayers == 3){
        	p1.transform.position = new Vector3(p1.transform.position.x + 7.5f, p1.transform.position.y, p1.transform.position.z);
        	p2.transform.position = new Vector3(p2.transform.position.x + 7.5f, p2.transform.position.y, p2.transform.position.z);
        	p3.transform.position = new Vector3(p3.transform.position.x + 7.5f, p3.transform.position.y, p3.transform.position.z);
        	p4.SetActive(false);
        }

        if(GameManager.winningPlayer == 1) winningBoat = p1;
        else if(GameManager.winningPlayer == 2) winningBoat = p2;
        else if(GameManager.winningPlayer == 3) winningBoat = p3;
        else winningBoat = p4;

        trav = winningBoat.transform.position - new Vector3(0,0,10);

    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(WaitBoatWait());
        if(waited && winningBoat.transform.position.z > trav.z){ 
        	winningBoat.transform.Translate(Vector3.back * 6f * Time.deltaTime, Space.World);
    	}

    	if(winningBoat.transform.position.z <= trav.z){
    		s.SetActive(true);
    		t.SetActive(true);
    		StartCoroutine(EndGame());
    	}
    }

    IEnumerator WaitBoatWait(){
    	yield return new WaitForSeconds(6f);
    	waited = true;
    }
    IEnumerator EndGame(){
    	yield return new WaitForSeconds(10f);
    	SceneManager.LoadScene("MainMenu");
    }
}
