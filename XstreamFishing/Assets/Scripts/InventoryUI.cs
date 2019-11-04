using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {

    public Inventory inventory;
    public Transform contentPanel;
    public GameObject inventoryEntry;

    // Use this for initialization
    void Start() 
    {
        RefreshDisplay ();
    }

    private void OnEnable() {
      Inventory.OnNumFishChange += HandleOnNumFishChange;
      Inventory.OnReceiveItem += HandleOnReceiveItem;
    }
 
    private void OnDisable() {
      Inventory.OnNumFishChange -= HandleOnNumFishChange;
      Inventory.OnReceiveItem -= HandleOnReceiveItem;
    }

    void HandleOnNumFishChange(int numFish) {
        // update numFish display
    }

    void HandleOnReceiveItem(Item item) {
      Debug.Log(item.itemName);
      RefreshDisplay();
    }


    public void RefreshDisplay()
    {
        RemoveEntries();
        AddEntries();
    }

    private void RemoveEntries()
    {
        while (contentPanel.childCount > 0) 
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            Destroy(toRemove);
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