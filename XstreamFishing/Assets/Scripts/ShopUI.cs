using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ShopUI : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public Inventory inventory;
    public static Action OnNotEnoughFish;
    public GameObject shopButton;
    private GameObject firstButton;
    public PlayerToastManager ptm;
    public Text description;
    public Text nameText;
    public Text priceText;
    public NextUpdateScript nextUpgrade;
    // public event Action OnUpdateDisplay;

    // Use this for initialization
    void Start()
    {
        // OnUpdateDisplay += UpdateDisplay;
        inventory.OnInventoryChange += UpdateDisplay;
    }

    void OnEnable()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        foreach (Transform child in contentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void UpdateDisplay(bool b) {
        RemoveButtons();
        AddButtons();
    }

    void Update()
    {
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = Instantiate(shopButton);
            newButton.transform.SetParent(contentPanel, false);
            newButton.transform.localScale = new Vector3(1f, 1f, 1f);
            newButton.transform.localPosition = Vector3.zero;
            newButton.transform.localRotation = Quaternion.identity;
            ShopButton newShopButton = newButton.GetComponent<ShopButton>();
            newShopButton.Setup(item, this);
            if(inventory.numFish < item.price) {
                Image im = newShopButton.GetComponent<Image>();
                im.color = new Color(0.1f, 0.1f, 0.1f, 1f);
            }
        }
    }


    public void TryTransferItemToInventory(Item item)
    {
        // if you have enough fish to buy
        if (inventory.numFish >= item.price)
        {
            item.isSelected = false;
            item.isEquipped = false;
            // subtract funds and give item
            inventory.numFish -= item.price;
            // yes came from shop
            inventory.AddItem(item, true);

            // delete all worse things and self from store if not consumable
            if (!item.isConsumable)
            {
                // placeholder large number
                int nextMultiplier = 300;
                Item nextItem = null;
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].category == item.category && (itemList[i].multiplier <= item.multiplier || itemList[i].itemName == item.itemName))
                    {
                        itemList.Remove(itemList[i]);
                    }

                    // find next object of this category, put the sprite in the panel, and set price in playermanager
                    if (itemList[i].category == item.category && itemList[i].multiplier > item.multiplier && itemList[i].multiplier < nextMultiplier)
                    {
                        nextItem = itemList[i];
                        nextMultiplier = nextItem.multiplier;
                    }
                    if (item.itemName == "Goldenrod")
                    {
                        nextItem = null;
                        // set audio manager to play shark music once someone buys
                        GameManager.SomeoneHasGoldenrod();
                    }
                }
                nextUpgrade.nextItem = nextItem;
                itemList.Remove(item);
            }

            // re-render
            UpdateDisplay(true);
        }
        // if not enough fish
        else
        {
            // emit not enough fish event
            if (OnNotEnoughFish != null)
            {
                OnNotEnoughFish();
            }
        }
    }
}