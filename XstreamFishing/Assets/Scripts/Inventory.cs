using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numFish;
    public Fishing fishing;
    public int rodMultiplier = 1;
    public int baitMultiplier = 1;

    public event Action OnNumFishChange;
    public event Action OnReceiveItem;
    public event Action OnInventoryChange;
    public List<Item> itemList;
    public List<Item> equippedList;

    void Start()
    {
        fishing.OnCatchFish += HandleOnNumFishChange;
    }

    public bool GetHasCategoryEquipped(string category) {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == category && itemList[i].isEquipped)
            {
                return true;
            }
        }
        return false;
    }

    
    public Item GetEquippedOfCategory(string category) {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == category && itemList[i].isEquipped)
            {
                return itemList[i];
            }
        }
        return itemList[0];
    }

    public void EquipItem(Item item, InventoryEntry ie) {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == item.category)
            {
                itemList[i].isEquipped = false;
                // ie.image.color = new Color32(255, 255, 255, 255);
            }
        }
        item.isEquipped = true;
    }

    public void UseCannonball() {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == "cannonball")
            {
                itemList[i].amount--;
                if(itemList[i].amount <= 0) {
                    itemList.Remove(itemList[i]);
                    OnInventoryChange();
                }
            }
        }
    }


    public void AddItem(Item item)
    {
        bool alreadyInList = false;
        Item foundItem = null;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemName == item.itemName)
            {
                alreadyInList = true;
                foundItem = itemList[i];
                break;
            }
        }

        // if it's a consumable
        if (item.isConsumable)
        {
            // if we already have it, increment amount
            if (alreadyInList)
            {
                foundItem.amount++;
            }
            // if we don't, add it to inventory
            else
            {
                itemList.Add(item);
            }
        }
        // if it's an upgrade
        else if (!item.isConsumable)
        {
            // delete the one of the same category (don't let them buy a worse one)
            bool removedOld = false;
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].category == item.category && itemList[i].multiplier <  item.multiplier)
                {
                    itemList.Remove(itemList[i]);
                    removedOld = true;
                    // set the proper multipliers
                    if (item.category == "rod")
                    {
                        rodMultiplier = item.multiplier;
                    }
                    break;
                }
            }
            if(removedOld) {
                // add the new item
                itemList.Add(item);
            }
        }
        // tell the inventory UI that we got this item
        if (OnReceiveItem != null)
        {
            OnReceiveItem();
        }
    }

    public void HandleOnNumFishChange(int numFishIn)
    {
        numFish += numFishIn;
        if (OnNumFishChange != null)
        {
            OnNumFishChange();
        }
    }

    public void HandleReceiveItem()
    {

    }

}
