using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextUpdateScript : MonoBehaviour
{
    public Item nextItem;
    public GameObject nextItemSprite;
    public Text nextItemText;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextItem == null)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Image>().sprite = nextItem.icon;
        nextItemText.text = (nextItem.price - inventory.numFish) + " RC";
    }
}
