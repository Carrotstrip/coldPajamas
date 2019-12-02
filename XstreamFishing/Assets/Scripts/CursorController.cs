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
            Debug.Log("button " + button.item.itemName);
        }
        else if(entry) {
            Debug.Log("entry " + entry);
        }
    }

    void OnTriggerEnter(Collider collider) {
        button = collider.gameObject.GetComponent<ShopButton>();
        entry = collider.gameObject.GetComponent<InventoryEntry>();

        if(button) {
            Debug.Log("button " + button.item.itemName);
            button.OnHover();
        }
        else if(entry) {
            Debug.Log("entry " + entry);
        }
    }

    void OnSubmit() {
        if(button) {
            button.HandleClick();
        }
        else if(entry) {
            entry.HandleClick();
        }
        else {
            Debug.Log("nothing to click");
        }
    }

    // Update is called once per frame
    void Update()
    {
        rt.Translate(move_vector);
        if(Input.GetAxis("Horizontal") < .1 && Input.GetAxis("Vertical") < .1 ) {
            move_vector = Vector2.zero;
        }
        // move_vector = Vector2.zero;
    }
}
