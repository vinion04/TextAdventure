using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeToggleController : MonoBehaviour
{

    public Text displayText;
    public Text themeToggleText;
    public Text inputText;
    public Text placeHolderText;
    public Text sizeToggleText;

    private bool bigText;

    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        bigText = toggle.isOn;
        int pref = PlayerPrefs.GetInt("text size", 1);

        if(pref == 1)
        {
            toggle.isOn = true;
            bigText = true;
        }
        else
        {
            toggle.isOn = false;
            bigText = false;
        }

        SetText();
        toggle.onValueChanged.AddListener(ProcessChange);
    }

    void ProcessChange(bool value)
    {
        bigText = value;
        PlayerPrefs.SetInt("text size", bigText ? 1 : 0);
        SetText();
    }

    void SetText()
    {
        if(bigText)
        {
            displayText.fontSize = 28;
            inputText.fontSize = 28;
            themeToggleText.fontSize = 14;
            sizeToggleText.fontSize = 14;
            placeHolderText.fontSize = 28;

        }
        else
        {
            displayText.fontSize = 24;
            inputText.fontSize = 24;
            themeToggleText.fontSize = 14;
            sizeToggleText.fontSize = 14;
            placeHolderText.fontSize = 24;
        }
    }
}
