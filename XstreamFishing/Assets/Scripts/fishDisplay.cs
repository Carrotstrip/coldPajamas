using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishDisplay : MonoBehaviour
{
	public Sprite minnow, smallmouthbass, largemouthbass, laketrout, whitebass, carp, yellowperch, whitefish, steelheadtrout, sunfish, walleye, muskelunge, northernpike, crappie, brooktrout, cohosalmon, atlanticsalmon, lakesturgeon;
	
	Image im;

	RectTransform rt;

	Sprite temp;

	Dictionary<int, Sprite> fishToSpriteDict;
    // Start is called before the first frame update
    void Start()
    {
			im = GetComponent<Image>();
    	im.preserveAspect = true;
    	rt = GetComponent<RectTransform>();

    	Color c = im.color;
    	c.a = 0;
    	im.color = c;
			fishToSpriteDict = new Dictionary<int, Sprite>() {
				{0, minnow},
				{1, smallmouthbass},
				{2, largemouthbass},
				{3, laketrout},
				{4, whitebass},
				{5, carp},
				{6, yellowperch},
				{7, whitefish},
				{8, steelheadtrout},
				{9, sunfish},
				{10, walleye},
				{11, muskelunge},
				{12, northernpike},
				{13, crappie},
				{14, brooktrout},
				{15, cohosalmon},
				{16, atlanticsalmon},
				{17, lakesturgeon}
    	};
    	
    }

    public void sendFish(int index){
    	temp = fishToSpriteDict[index];
    	im.sprite = temp;
    	Color c = im.color;
    	c.a = 100;
    	im.color = c;
    	StartCoroutine(ShowFish());
    }

    IEnumerator ShowFish(){
    	yield return new WaitForSeconds(2f);
    	Color c = im.color;
    	c.a = 0;
    	im.color = c;

    }
}
