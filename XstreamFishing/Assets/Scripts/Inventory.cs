using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text fish_count_text;
    public int numFish;

    public CastLine castLine;

    public event Action<int> OnCatchFish;

    public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {
        numFish = 0;
        fish_count_text.text = "Press Z to cast";
    }


    private void OnEnable() {
        castLine.OnCatchFish += HandleOnCatchFish;
    }
 
    private void OnDisable() {
        castLine.OnCatchFish -= HandleOnCatchFish;
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public void HandleOnCatchFish(int numFish) {
        OnCatchFish(numFish);
    }

    public void HandleBuyItem() {


    }
    public void AddFish(){
        ++numFish;
        fish_count_text.text = "Fish: " + numFish.ToString();
    }
}
