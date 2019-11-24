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

    // Use this for initialization
    void Start()
    {
        RefreshDisplay(false);
        inventory.OnInventoryChange += RefreshDisplay;
    }

    void OnEnable() {

    }


    public void RefreshDisplay(bool fromShop)
    {
        fishCount.text = "Fish: " + inventory.numFish.ToString();
        RemoveEntries();
        AddEntries(fromShop);
    }

    private void RemoveEntries()
    {
        foreach (Transform child in contentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void AddEntries(bool fromShop)
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
            if(!fromShop && (i == 0 || item.isSelected)) {
                EventSystem.current.SetSelectedGameObject(newEntry);
            }
        }
    }

}