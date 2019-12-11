using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    RectTransform rt;
    RectTransform crt;
    Vector2 move_vector;
    float speed = .02f;
    ShopButton button;
    InventoryEntry entry;
    Canvas canvas;
    float canvasWidth;
    float canvasHeight;
    // Start is called before the first frame update
    void Start()
    {   
        canvas = transform.parent.GetComponent<Canvas>();
        crt = canvas.GetComponent<RectTransform>();
    }

    void OnEnable() {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(200f, -200f);
    }

    void OnMoveCursor(InputValue input)
    {
        move_vector = input.Get<Vector2>();
        move_vector.x *= speed;
        move_vector.y *= speed;
        // canvasWidth = canvas.transform.GetComponent<RectTransform>().rect.width;
        // canvasHeight = canvas.transform.GetComponent<RectTransform>().rect.height;
    }

    void OnTriggerExit(Collider collider) {
        button = null;
        entry = null;
    }

    void OnTriggerStay(Collider collider) {
        button = collider.gameObject.GetComponent<ShopButton>();
        entry = collider.gameObject.GetComponent<InventoryEntry>();
        if(button) {
            button.OnHover();
        }
        else {
            // Debug.Log("nothing to click");
        }
    }

    void OnTriggerEnter(Collider collider) {
        button = collider.gameObject.GetComponent<ShopButton>();
        entry = collider.gameObject.GetComponent<InventoryEntry>();
    }

    void OnSubmit() {
        if(button) {
            button.HandleClick();
        }
        else if(entry) {
            entry.HandleClick();
        }
        else {
            // Debug.Log("nothing to click");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rt.anchoredPosition.x < crt.rect.width && rt.anchoredPosition.x > 0 && rt.anchoredPosition.y > -crt.rect.height && rt.anchoredPosition.y < 0){
             rt.Translate(move_vector);
        }

        if(rt.anchoredPosition.x <= 0){
            rt.anchoredPosition = new Vector2(10, rt.anchoredPosition.y);
        }
        else if(rt.anchoredPosition.x >= crt.rect.width){
            rt.anchoredPosition = new Vector2(crt.rect.width - 10, rt.anchoredPosition.y);
        }
        
        if(rt.anchoredPosition.y >= 0){
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -10);
        }
        else if(rt.anchoredPosition.y <= -crt.rect.height){
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -crt.rect.height + 10);
        }
        Debug.Log(Input.GetAxis("Horizontal"));
        if(Mathf.Abs(Input.GetAxis("Horizontal")) < .01 && Mathf.Abs(Input.GetAxis("Vertical")) < .01) {
            move_vector = Vector2.zero;
        }
        // move_vector = Vector2.zero;
    }
}
