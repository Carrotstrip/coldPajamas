using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numFish;

    public CastLine castLine;

    public static event Action<int> OnNumFishChange;
    public static event Action<Item> OnReceiveItem;
    public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {
        numFish = 0;
    }


    private void OnEnable() {
        // call rhs function when lhs event fires
        CastLine.OnCatchFish += HandleOnNumFishChange;
    }
 
    private void OnDisable() {
        CastLine.OnCatchFish -= HandleOnNumFishChange;
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        if(OnReceiveItem != null) {
            Debug.Log("onReceiveItem");
            OnReceiveItem(item);
        }
    }

    public void HandleOnNumFishChange(int numFish) {
        OnNumFishChange(numFish);
    }

    public void HandleReceiveItem() {

    }

    public void AddFish(){
        ++numFish;
    }
}
