using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MultiplayerButton : Button
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
        eventSystem = GetComponent<EventSystemProvider>().eventSystem;
    }
 
    public override void Select()
    {
        if (eventSystem.alreadySelecting)
            return;
 
        eventSystem.SetSelectedGameObject(gameObject);
    }
}