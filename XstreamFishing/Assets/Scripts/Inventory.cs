using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numFish;

    public CastLine castLine;

    public event Action<int> OnNumFishChange;

    public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {
        numFish = 0;
        
    }


    private void OnEnable() {
        castLine.OnCatchFish += HandleOnNumFishChange;
    }
 
    private void OnDisable() {
        castLine.OnCatchFish -= HandleOnNumFishChange;
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public void HandleOnNumFishChange(int numFish) {
        OnNumFishChange(numFish);
    }

    public void HandleBuyItem() {

    }

    public void AddFish(){
        ++numFish;
    }
}
