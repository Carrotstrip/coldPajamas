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


    // Use this for initialization
    void Start()
    {
    }

    void OnEnable() {
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
            if(i == 0) {
                Debug.Log("setting newButton " + newButton);
                EventSystem.current.SetSelectedGameObject(newButton);
            }
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
        // if (item.category == "cannonball"){
        //     ptm.Toast("Cannnnonon");
        // }
    }
}