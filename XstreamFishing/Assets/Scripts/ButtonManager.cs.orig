using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public Button b2;
    // Start is called before the first frame update
    void Start()
    {
        Button btn2 = b2.GetComponent<Button>();
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

    void LoadMP()
    {
        GameManager.game_started = false;
        SceneManager.LoadScene("MultiplayerScene");
    }
}
