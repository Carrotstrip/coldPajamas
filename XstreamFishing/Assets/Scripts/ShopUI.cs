using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public Inventory inventory;
    public static Action OnNotEnoughFish;

    public GameObject shopButton;


    // Use this for initialization
    void Start()
    {
        AddButtons();
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
        // if you have enough fish to buy
        if (inventory.numFish >= item.price)
        {
            // subtract funds and give item
            inventory.numFish -= item.price;
            inventory.AddItem(item);
        }
        // if not enough fish
        else {
            // emit not enough fish event
            if(OnNotEnoughFish != null) {
                OnNotEnoughFish();
            }
        }
    }
}