using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public Inventory inventory;
    public static Action OnNotEnoughFish;
    //public EventSystem es;
    

    public GameObject shopButton;
    private GameObject firstButton;


    // Use this for initialization
    void Start()
    {
        AddButtons();
        //EventSystem.current.SetSelectedGameObject(firstButton);
        //StartCoroutine(SelectButton());
        
        
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
            if(i == 0){
                Image im = newShopButton.GetComponent<Image>();
                im.color = new Color32(0xC0,0x7D,0x30,0xFF);
                firstButton = newButton;
                //newShopButton.Color = #C07D30;
               // StartCoroutine("SelectButton");
                EventSystem.current.SetSelectedGameObject(firstButton);
            }
           
        }
    }

    void Update(){
        GameObject temp = EventSystem.current.currentSelectedGameObject;
        // if(temp != firstButton){
        //     ShopButton tempShop = firstButton.GetComponent<ShopButton>();
        //     Image im = tempShop.GetComponent<Image>();
        //     im.color = new Color32(0xFF,0xFF,0xFF,0xFF);
        // }
        // if(temp.tag == "button"){
        //     ShopButton btn = temp.GetComponent<ShopButton>();
        //     Debug.Log(btn.nameLabel.text);
        // }
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