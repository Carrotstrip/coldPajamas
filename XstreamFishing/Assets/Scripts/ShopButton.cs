using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopButton : MonoBehaviour {

    // public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;
    public Text priceText;
    public Item item;
    private ShopUI scrollList;
    public bool hovered;
    private Image im;
    private Color og;

    // Use this for initialization
    void Start () 
    {
        // buttonComponent.onClick.AddListener(HandleClick);
        im = GetComponent<Image>();
        og = im.color;
    }

    public void Setup(Item currentItem, ShopUI currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        priceText.text = item.price.ToString();
        scrollList = currentScrollList;
    }

    public void OnHover()
    {
        scrollList.description.text = item.description;
        scrollList.nameText.text = item.itemName.ToString();
        scrollList.priceText.text = item.price.ToString();
    }

    public void OnTriggerExit(Collider coll){
        im.color = og;
    }

    public void OnTriggerEnter(Collider coll){
        Color c = new Color(0.66f, 0.58f, 0.53f, 1f);
        im.color = c;
    }

    public void HandleClick()
    {
        scrollList.inventory.UnselectAll();
        scrollList.inventory.SetSelected(item);
        scrollList.TryTransferItemToInventory(item);
    }
}