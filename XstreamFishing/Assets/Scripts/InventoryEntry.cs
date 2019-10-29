using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryEntry : MonoBehaviour {

    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;


    private Item item;
    private InventoryUI thisUI;

    // Use this for initialization
    void Start () 
    {
    }

    public void Setup(Item currentItem, InventoryUI currentUI)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        thisUI = currentUI;

    }
}