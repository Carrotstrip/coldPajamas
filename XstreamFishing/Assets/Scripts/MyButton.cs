using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MyButton : Button
{
    public EventSystem eventSystem;
 
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
 
        // Selection tracking
        if (IsInteractable() && navigation.mode != Navigation.Mode.None)
            eventSystem.SetSelectedGameObject(gameObject, eventData);
 
        base.OnPointerDown(eventData);
    }

    protected override void Awake()
    {
        base.Awake();
        eventSystem = GameObject.Find("MyEventSystem").GetComponent<EventSystem>();
        Debug.Log(eventSystem);
        // eventSystem = GetComponent<MyEventSystem>
    }
 
    public override void Select()
    {
        Debug.Log("selecting");
        if (eventSystem.alreadySelecting)
            return;
 
        eventSystem.SetSelectedGameObject(gameObject);
    }
}