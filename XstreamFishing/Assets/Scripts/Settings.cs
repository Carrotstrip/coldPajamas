using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{
    public GameObject settingsImage;
    private Fishing f;
    void Start()
    {
        f = GetComponent<Fishing>();
        settingsImage.SetActive(false);
    }

    void OnStartButton()
    {
        settingsImage.SetActive(!settingsImage.activeSelf);
        f.enabled = !f.enabled;
    }
}
