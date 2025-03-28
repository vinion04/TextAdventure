using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Image background;
    public Text displayText;
    public Text themeToggleText;
    public Text inputText;
    public Text placeHolderText;
    public Text sizeToggleText;

    private bool darkMode;

    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        darkMode = toggle.isOn;
        int pref = PlayerPrefs.GetInt("theme", 1);

        if (pref == 1)
        {
            toggle.isOn = true;
            darkMode = true;
        }
        else
        {
            toggle.isOn = false;
            darkMode = false;
        }

        SetTheme();
        toggle.onValueChanged.AddListener(ProcessChange);
    }

    void ProcessChange(bool value)
    {
        darkMode = value;
        PlayerPrefs.SetInt("theme", darkMode ? 1 : 0);
        SetTheme();
    }

    void SetTheme()
    {
        if(darkMode)
        {
            background.color = Color.black;
            displayText.color = Color.white;
            themeToggleText.color = Color.white;
            inputText.color = Color.white;
            placeHolderText.color = Color.white;
            sizeToggleText.color = Color.white;
        }
        else
        {
            background.color = Color.white;
            displayText.color = Color.black;
            themeToggleText.color = Color.black;
            inputText.color = Color.black;
            placeHolderText.color = Color.black;
            sizeToggleText.color = Color.black;
        }
    }
}
