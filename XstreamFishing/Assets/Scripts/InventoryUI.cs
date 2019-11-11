using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{

    public Inventory inventory;
    public Transform contentPanel;
    public GameObject inventoryEntry;
    public Text fishCount;

    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
        inventory.OnNumFishChange += RefreshDisplay;
        inventory.OnReceiveItem += RefreshDisplay;
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
            Debug.Log("adding entries");
            Item item = inventory.itemList[i];
            Debug.Log(item.itemName);
            GameObject newEntry = Instantiate(inventoryEntry);
            newEntry.transform.SetParent(contentPanel);
            newEntry.transform.localScale = new Vector3(1f, 1f, 1f);
            InventoryEntry newInvEntry = newEntry.GetComponent<InventoryEntry>();
            
            newInvEntry.Setup(item, this);
        }
    }

}