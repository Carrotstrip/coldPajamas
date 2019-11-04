using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public bool isConsumable = true;
    public string category = "";
    public Sprite icon;
    public int price = 1;
    public int amount = 1;
    public int multiplier = 0;
}

public class ShopScrollList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public Inventory inventory;
    public Text fishDisplayText;

    public GameObject shopButton;


    // Use this for initialization
    void Start () 
    {
        AddButtons();
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        fishDisplayText.text = "Fish: " + inventory.numFish.ToString();
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++) 
        {
            Item item = itemList[i];
            GameObject newButton = Instantiate(shopButton);
            newButton.transform.SetParent(contentPanel);
            newButton.transform.localScale = new Vector3(1f, 1f, 1f);
            ShopButton newShopButton = newButton.GetComponent<ShopButton>();
            newShopButton.Setup(item, this);
        }
    }

    public void TryTransferItemToInventory(Item item)
    {
        if (inventory.numFish >= item.price) 
        {
            inventory.numFish -= item.price;
            inventory.AddItem(item);
        }
    }
}