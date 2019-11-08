using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

	public Button b1, b2;
    // Start is called before the first frame update
    void Start()
    {
     	Button btn1 = b1.GetComponent<Button>();
		btn1.onClick.AddListener(LoadSP);

		Button btn2 = b2.GetComponent<Button>();
		btn2.onClick.AddListener(LoadMP);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSP(){
    	SceneManager.LoadScene("SingleplayerScene");
    }

    void LoadMP(){
    	SceneManager.LoadScene("MultiplayerScene");
    }
}
