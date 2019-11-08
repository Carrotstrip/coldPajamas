using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update    public GameObject boat;
    public GameObject settingsImage;
    private Fishing f;
    void Start()
    {
        f = GetComponent<Fishing>();
        settingsImage.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.startButton.wasPressedThisFrame){
           settingsImage.SetActive(!settingsImage.activeSelf); 
           f.enabled = !f.enabled;
        }
    }
}
