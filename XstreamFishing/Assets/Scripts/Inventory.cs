using System;
using System.Collections.Generic;
using UnityEngine;

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
        fishing.OnCatchFish += HandleOnCatchFish;
    }

    void Update()
    {
    }

    public bool GetHasCategoryEquipped(string category)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == category && itemList[i].isEquipped)
            {
                return true;
            }
        }
        return false;
    }

    public void DropItem()
    {
        int ixToDrop = UnityEngine.Random.Range(0, itemList.Count);
        if (itemList.Count > 0)
        {
            itemList.Remove(itemList[ixToDrop]);
        }
        if (OnInventoryChange != null)
        {
            OnInventoryChange();
        }
    }

    public int DropFish(int multiplier)
    {
        int numToDrop = UnityEngine.Random.Range(0, numFish / 5 * multiplier);
        numFish -= numToDrop;
        if (OnInventoryChange != null)
        {
            OnInventoryChange();
        }
        return numToDrop;
    }

    public Item GetEquippedOfCategory(string category)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == category && itemList[i].isEquipped)
            {
                return itemList[i];
            }
        }
        Item fillerItem = new Item();
        return fillerItem;
    }

    public void EquipItem(Item item, InventoryEntry ie)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == item.category)
            {
                itemList[i].isEquipped = false;
            }
        }
        item.isEquipped = true;
        if (item.category == "rod")
        {
            rodMultiplier = item.multiplier;
        }
        if (item.category == "bait")
        {
            baitMultiplier = item.multiplier;
        }
    }

    public void UseCannonball()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == "cannonball")
            {
                itemList[i].amount--;
                if (itemList[i].amount <= 0)
                {
                    itemList.Remove(itemList[i]);
                }
                if (OnInventoryChange != null)
                {
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
                if (itemList[i].category == item.category && itemList[i].multiplier <= item.multiplier)
                {
                    itemList.Remove(itemList[i]);
                    removedOld = true;
                    // set the proper multipliers
                    break;
                }
            }
            // add the new item
            itemList.Add(item);
        }
        // tell the inventory UI that we got this item
        if (OnInventoryChange != null)
        {
            OnInventoryChange();
        }
    }

    public void HandleOnCatchFish(int numFishIn)
    {
        GainFish(numFishIn);
        Item bait = GetEquippedOfCategory("bait");
        if (bait != null)
        {
            bait.amount -= 1;
        }
        if(OnInventoryChange != null) {
            OnInventoryChange();
        }
    }

    public void GainFish(int numFishIn) {
        numFish += numFishIn;
    }
}
