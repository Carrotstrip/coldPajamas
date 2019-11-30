using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryEntry : MonoBehaviour {

    public bool isSelected;
    public Text amountLabel;
    public Image iconImage;
    public Image image;
    private Item item;
    private InventoryUI thisUI;

    
    void Start ()
    {
        image = GetComponent<Image>();
    }

    public void HandleClick()
    {
        Debug.Log("eatmyass.ppm");
        thisUI.inventory.EquipItem(item, this);
        thisUI.inventory.UnselectAll();
        thisUI.inventory.SetSelected(item);
        thisUI.RefreshDisplay(false);
    }

    public void OnSubmit() {
        Debug.Log("eatmyass.png");
    }


    public void Setup(Item currentItem, InventoryUI currentUI)
    {
        item = currentItem;
        isSelected = item.isSelected;
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