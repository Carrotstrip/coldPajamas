using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryEntry : MonoBehaviour {

    public Button buttonComponent;
    // public Text nameLabel;
    public Text amountLabel;
    public Image iconImage;
    public Image image;
    private Item item;
    private InventoryUI thisUI;

    
    void Start () 
    {
        buttonComponent.onClick.AddListener(HandleClick);
        image = GetComponent<Image>();
    }

    public void HandleClick()
    {
        thisUI.inventory.EquipItem(item, this);
        image.color = new Color32(200, 10, 10, 255);
        thisUI.RefreshDisplay();
    }

    public void Setup(Item currentItem, InventoryUI currentUI)
    {
        item = currentItem;
        // nameLabel.text = item.itemName;
        amountLabel.text = currentItem.amount.ToString();
        iconImage.sprite = item.icon;
        thisUI = currentUI;
        image = GetComponent<Image>();
        if(item.isEquipped) {
            image.color = new Color32(200, 10, 10, 255);
        }
        else {
            image.color = new Color32(255, 255, 255, 255);
        }

    }
}