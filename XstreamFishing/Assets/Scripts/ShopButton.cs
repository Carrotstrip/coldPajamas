using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour {

    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;
    public Text priceText;
    public EventSystem es;


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

    void Update(){
        
        if(Input.GetKeyDown(KeyCode.T)){
            scrollList.TryTransferItemToInventory(item);
        }
    }

    public void HandleClick()
    {
        Debug.Log("Clicked " + item.itemName);
        scrollList.TryTransferItemToInventory(item);
    }
}