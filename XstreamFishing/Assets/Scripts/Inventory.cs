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
    public event Action<bool> OnInventoryChange;
    public event Action GotPropeller;
    public List<Item> itemList;
    private PlayerToastManager ptm;

    void Start()
    {
        fishing.OnCatchFish += HandleOnCatchFish;
        ptm = gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
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
            OnInventoryChange(false);
        }
    }

    public int DropFish(int multiplier)
    {
        int numToDrop = 0;
        if (numFish > 0)
        {
            numToDrop = UnityEngine.Random.Range(1, numFish / 5 * multiplier);
        }
        numFish -= numToDrop;
        if (OnInventoryChange != null)
        {
            OnInventoryChange(false);
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
        // un-equip other items of this category
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == item.category)
            {
                itemList[i].isEquipped = false;
            }
        }

        item.isEquipped = true;
        ie.image.color = new Color32(200, 10, 10, 255);

        if (item.category == "rod")
        {
            rodMultiplier = item.multiplier;
        }
        if (item.category == "bait")
        {
            baitMultiplier = item.multiplier;
        }

        if (OnInventoryChange != null)
        {
            OnInventoryChange(false);
        }
    }

    public void UnselectAll()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].isSelected = false;
        }
    }

    public void SetSelected(Item item)
    {
        item.isSelected = true;
    }

    public void UseCannonball()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].category == "cannonball" && itemList[i].isEquipped)
            {
                itemList[i].amount--;
                if (itemList[i].amount <= 0)
                {
                    itemList.Remove(itemList[i]);
                }
                if (OnInventoryChange != null)
                {
                    OnInventoryChange(false);
                }
            }
        }
    }


    public void AddItem(Item item, bool fromShop)
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

        // if(!GetHasCategoryEquipped(item.category)) {
        //     if(item.category == "bait") {
        //         ptm.Toast("Go ahead and equip your bait in the inventory,\nyou might land yourself a real lunker hoss!");
        //     }
        //     else if(item.category == "cannonball") {
        //         ptm.Toast("Whoa there, looks like you're trying to get into sum trouble!\nHit the right trigger to fire.\n Use the left trigger and bumper to adjust your angle.");
        //     }
        // }

        if (item.itemName == "Mysterious Propeller")
        {
            GotPropeller();
            ptm.Toast("Got that from my grandpa back in forty-thrinty-91. Not sure what it does,\nbut that old guy sure loved holding the A button!");
        }

        // if it's a consumable
        if (item.isConsumable)
        {
            // if we already have it, increment amount
            if (alreadyInList)
            {
                foundItem.amount += item.shopAmount;
            }
            // if we don't, add it to inventory
            else
            {
                itemList.Add(item);
                item.amount += item.shopAmount;
            }
        }
        // if it's an upgrade
        else if (!item.isConsumable)
        {
            // delete the one of the same category (don't let them buy a worse one)
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].category == item.category && itemList[i].multiplier <= item.multiplier)
                {
                    itemList.Remove(itemList[i]);
                    // set the proper multipliers
                    break;
                }
            }
            // add the new item
            itemList.Add(item);
            item.amount += item.shopAmount;
        }

        // tell the inventory UI that we got this item
        if (OnInventoryChange != null)
        {
            // request came from shop
            OnInventoryChange(fromShop);
        }
    }

    public void HandleOnCatchFish(int numFishIn)
    {
        GainFish(numFishIn);
        Item bait = GetEquippedOfCategory("bait");
        if (bait != null)
        {
            bait.amount -= 1;
            if (bait.amount <= 0)
            {
                itemList.Remove(bait);
                bait.isEquipped = false;
                baitMultiplier = 0;
            }
        }
        if (OnInventoryChange != null)
        {
            OnInventoryChange(false);
        }
    }

    public void GainFish(int numFishIn)
    {
        numFish += numFishIn;
    }
}
