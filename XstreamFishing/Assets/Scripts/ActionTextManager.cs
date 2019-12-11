using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTextManager : MonoBehaviour
{
    private Text actionText;
    private int num_lines;

    // Start is called before the first frame update
    void Start()
    {
        actionText = gameObject.GetComponent<Text>();
        actionText.text = "";
        num_lines = 0;
    }

    public void AddLine(string buttonName, string controlName)
    {
        if (num_lines == 0)
        {
            actionText.text = controlName;
        }
        else
        {
            actionText.text += "\n" + controlName;
        }

        // find corresponding button, set active, and position correctly based on num lines
        GameObject button = actionText.gameObject.GetComponent<RectTransform>().Find(buttonName).gameObject;
        button.SetActive(true);
        button.transform.localPosition = new Vector3(-285f, 45f - num_lines * 22f, 1f);
        num_lines += 1;
    }

    public void ClearActions()
    {
        actionText.text = "";
        // iterate and set all children unactive
        // just kidding instead of iterating we're going to hardcode this and it's going to look awful but that's okay
        GameObject button = actionText.gameObject.GetComponent<RectTransform>().Find("A").gameObject;
        button.SetActive(false);
        button = actionText.gameObject.GetComponent<RectTransform>().Find("B").gameObject;
        button.SetActive(false);
        button = actionText.gameObject.GetComponent<RectTransform>().Find("X").gameObject;
        button.SetActive(false);
        button = actionText.gameObject.GetComponent<RectTransform>().Find("Y").gameObject;
        button.SetActive(false);
        button = actionText.gameObject.GetComponent<RectTransform>().Find("LT").gameObject;
        button.SetActive(false);
        button = actionText.gameObject.GetComponent<RectTransform>().Find("LB").gameObject;
        button.SetActive(false);
        button = actionText.gameObject.GetComponent<RectTransform>().Find("RT").gameObject;
        button.SetActive(false);
        num_lines = 0;
    }
}
