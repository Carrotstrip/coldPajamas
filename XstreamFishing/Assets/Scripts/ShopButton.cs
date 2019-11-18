using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopButton : MonoBehaviour {

    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;
    public Text priceText;
    private Item item;
    private ShopUI scrollList;

    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, ShopUI currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        priceText.text = item.price.ToString();
        scrollList = currentScrollList;
    }


    public void HandleClick()
    {
        scrollList.inventory.UnselectAll();
        scrollList.TryTransferItemToInventory(item);
    }
}