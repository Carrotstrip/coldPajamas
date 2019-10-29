using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text fish_count_text;
    public int numFish;
    // Start is called before the first frame update
    void Start()
    {
        numFish = 0;
        fish_count_text.text = "Press Z to cast";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddFish(){
        ++numFish;
        fish_count_text.text = "Fish: " + numFish.ToString();
    }
}
