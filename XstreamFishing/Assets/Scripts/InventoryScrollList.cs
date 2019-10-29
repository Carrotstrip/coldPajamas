using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryScrollList : MonoBehaviour {

    public Inventory inventory;
    public Transform contentPanel;

    // Use this for initialization
    void Start () 
    {
        // RefreshDisplay ();
    }

    // public void RefreshDisplay()
    // {
    //     RemoveButtons ();
    //     AddButtons ();
    // }

    // private void RemoveButtons()
    // {
    //     while (contentPanel.childCount > 0) 
    //     {
    //         GameObject toRemove = transform.GetChild(0).gameObject;
    //         buttonObjectPool.ReturnObject(toRemove);
    //     }
    // }

    // private void AddButtons()
    // {
    //     for (int i = 0; i < inventory.itemList.Count; i++) 
    //     {
    //         Item item = inventory.itemList[i];
    //         GameObject newEntry = buttonObjectPool.GetObject();
    //         newEntry.transform.SetParent(contentPanel);

    //         InventoryEntry invEntry = newEntry.GetComponent<InventoryEntry>();
    //         invEntry.Setup(item, this);
    //     }
    // }

}