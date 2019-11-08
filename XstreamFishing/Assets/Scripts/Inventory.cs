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
    public Text fishText;

    public static event Action<int> OnNumFishChange;
    public static event Action<Item> OnReceiveItem;
    public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {
        numFish = 0;
    }

    private void OnEnable()
    {
        Fishing.OnCatchFish += HandleOnNumFishChange;
    }

    private void OnDisable()
    {
        Fishing.OnCatchFish -= HandleOnNumFishChange;
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
            // delete the one of the same category
            bool removed = false;
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].category == item.category)
                {
                    itemList.Remove(itemList[i]);
                    removed = true;
                    if (item.category == "rod")
                    {
                        rodMultiplier = item.multiplier;
                    }
                    else if (item.category == "bait")
                    {
                        baitMultiplier = item.multiplier;
                    }
                    break;
                }
            }
            // add the new item
            itemList.Add(item);
        }
        if (OnReceiveItem != null)
        {
            OnReceiveItem(item);
        }
    }

    public void HandleOnNumFishChange(int numFishIn)
    {
        numFish += numFishIn;
        if (OnNumFishChange != null)
        {
            OnNumFishChange(numFish);
        }
    }

    public void HandleReceiveItem()
    {

    }

}
