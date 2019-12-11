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
    public GameObject finjamin_sprite;
    public GameObject fin_sprite;

    // Start is called before the first frame update
    void Start()
    {
        fin_sprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextItem == null || inventory.GetEquippedOfCategory("rod").itemName == "Goldenrod")
        {
            // if player has bought goldenrod, change text to something about shark
            // and set finjamin sprite to shark fin
            nextItemText.text = "Find the shark!";
            fin_sprite.SetActive(true);
            finjamin_sprite.SetActive(false);
            Image img = gameObject.GetComponent<Image>();
            var tempColor = img.color;
            tempColor.a = 0f;
            img.color = tempColor;
            // Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = nextItem.icon;
            nextItemText.text = (nextItem.price - inventory.numFish) + "\n\nto go";
            finjamin_sprite.SetActive(true);
            if (nextItem.price - inventory.numFish <= 0)
            {
                nextItemText.text = "Head to Jimbo's";
                finjamin_sprite.SetActive(false);
            }
        }
    }
}
