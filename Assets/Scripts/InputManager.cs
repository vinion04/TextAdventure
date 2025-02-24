using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Text storyText; // the story 
    public InputField userInput; // the input field object
    public Text inputText; // part of the input field where user enters response
    public Text placeHolderText; // part of the input field for initial placeholder text
    
    private string story; // holds the story to display
    private List<string> commands = new List<string>(); //valid user comments

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        commands.Add("go");
        commands.Add("get");

        userInput.onEndEdit.AddListener(UpdateStory);
        story = storyText.text;
    }

    public void UpdateStory(string msg)
    {
        if(msg != "")
        {
            char[] splitInfo = { ' ' }; //split characters on space
            string[] parts = msg.ToLower().Split(splitInfo);

            if (commands.Contains(parts[0]))        //if valid command
            {
                story += "\n" + msg;
                storyText.text = story;
            }

        }

        userInput.text = "";    //after input from user, reset
        userInput.ActivateInputField();
    }
}
