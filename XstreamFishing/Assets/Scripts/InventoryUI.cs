using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{

    public Inventory inventory;
    public Transform contentPanel;
    public GameObject inventoryEntry;
    public Text fishCount;
    EventSystem es;

    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
        inventory.OnInventoryChange += RefreshDisplay;
    }


    public void RefreshDisplay()
    {
        fishCount.text = "Fish: " + inventory.numFish.ToString();
        RemoveEntries();
        AddEntries();
    }

    private void RemoveEntries()
    {
        foreach (Transform child in contentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void AddEntries()
    {
        for (int i = 0; i < inventory.itemList.Count; i++)
        {
            Item item = inventory.itemList[i];
            GameObject newEntry = Instantiate(inventoryEntry);
            newEntry.transform.SetParent(contentPanel);
            newEntry.transform.localPosition = Vector3.zero;
            newEntry.transform.localRotation = Quaternion.identity;
            newEntry.transform.localScale = new Vector3(1f, 1f, 1f);
            InventoryEntry newInvEntry = newEntry.GetComponent<InventoryEntry>();
            newInvEntry.Setup(item, this);
            if(i == 0 || item.isSelected) {
                EventSystem.current.SetSelectedGameObject(newEntry);
            }
        }
    }

}