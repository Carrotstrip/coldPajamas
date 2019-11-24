using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public string description;
    public bool isSelected;
    public bool isConsumable = true;
    public bool isEquipped = false;
    public string category = "";
    public Sprite icon;
    public int price = 1;
    public int amount = 1;
    public int multiplier = 0;
}