using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int price = 1;
}

public class ShopScrollList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public Inventory inventory;
    public InventoryScrollList inventoryScrollList;
    public Text fishDisplay;


    // Use this for initialization
    void Start () 
    {
        RefreshDisplay ();
    }

    void Update () {
      RefreshDisplay();
    }

    void RefreshDisplay()
    {
        fishDisplay.text = "Fish: " + inventory.numFish.ToString();
        RemoveButtons ();
        AddButtons ();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0) 
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++) 
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            ShopButton shopButton = newButton.GetComponent<ShopButton>();
            shopButton.Setup(item, this);
        }
    }

    public void TryTransferItemToInventory(Item item)
    {
        if (inventory.numFish >= item.price) 
        {

            inventory.numFish -= item.price;

            AddItem(item, inventory);
            RemoveItem(item, this);

            RefreshDisplay();
            // inventoryScrollList.RefreshDisplay();

        }
    }

    void AddItem(Item itemToAdd, Inventory inventory)
    {
        inventory.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--) 
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
}