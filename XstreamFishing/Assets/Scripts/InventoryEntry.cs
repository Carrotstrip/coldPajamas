using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryEntry : MonoBehaviour {

    public Button buttonComponent;
    public Text nameLabel;
    public Text amountLabel;
    public Image iconImage;
    private Item item;
    private InventoryUI thisUI;

    
    void Start () 
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void HandleClick()
    {
        // thisUI.EquipItem(item);
    }

    public void Setup(Item currentItem, InventoryUI currentUI)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        amountLabel.text = currentItem.amount.ToString();
        iconImage.sprite = item.icon;
        thisUI = currentUI;

    }
}