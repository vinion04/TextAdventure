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
    public delegate void Restart();
    public event Restart onRestart;

    public Button commandsButton;
    
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
        commands.Add("restart");
        commands.Add("save");
        commands.Add("inventory");

        userInput.onEndEdit.AddListener(GetInput);
        story = storyText.text;
        NavigationManager.instance.onGameOver += EndGame;
        
        commandsButton.onClick.AddListener(DisplayCommands);
    }

    void EndGame()
    {
        UpdateStory("\nPlease enter 'restart' to play again.");
    }

    public void UpdateStory(string msg)
    {
        story += "\n" + msg;
        storyText.text = story;
    }

    void GetInput(string msg)
    {
        if (msg != "")
        {
            char[] splitInfo = { ' ' }; //split characters on space
            string[] parts = msg.ToLower().Split(splitInfo);

            if (commands.Contains(parts[0]))        //if valid command
            {
                if (parts[0] == "go")   //switch rooms
                {
                    if (NavigationManager.instance.SwitchRooms(parts[1]))   //return true or false
                    {
                        //fill in later
                    }
                    else
                        UpdateStory("Exit does not exist or is locked. Try again.");
                }

                else if (parts[0] == "get")
                {
                    if (NavigationManager.instance.TakeItem(parts[1]))   //return true or false
                    {
                        GameManager.instance.inventory.Add(parts[1]);
                        UpdateStory("You added a(n) " + parts[1] + " to your inventory.");
                    }
                    else
                        UpdateStory(parts[1] + " does not exist in this room. Try again.");
                }
                else if (parts[0] == "restart")
                {
                    if (onRestart != null)   //if anyone is listening
                        onRestart();
                }
                else if(parts[0] == "save")
                {
                    GameManager.instance.Save();
                }
                else if(parts[0] == "inventory")
                {
                    UpdateStory("------INVENTORY------");
                    for(int i=0;i<GameManager.instance.inventory.Count;i++)
                    {
                        UpdateStory(GameManager.instance.inventory[i]);
                    }
                }
            }
        }

        userInput.text = "";    //after input from user, reset
        userInput.ActivateInputField();
    }

    private void DisplayCommands()
    {
        UpdateStory("------COMMANDS------");
        for(int i=0;i<commands.Count;i++)
        {
            UpdateStory(commands[i]);
        }
    }
}
