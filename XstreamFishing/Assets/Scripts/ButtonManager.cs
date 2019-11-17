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
        Button btn2 = b2.GetComponent<Button>();
        btn1.onClick.AddListener(quitGame);
        btn2.onClick.AddListener(LoadMP);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnA()
    {
        LoadMP();
    }

    void OnB()
    {
        quitGame();
    }

    void quitGame(){
        Application.Quit();
    }

    void LoadMP()
    {
        GameManager.game_started = false;
        SceneManager.LoadScene("MultiplayerScene");
    }
}
