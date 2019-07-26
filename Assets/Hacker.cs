using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game States
    int level;
    string plyrname;
    enum Screen { Intro, MainMenu, Password, WinLoss }
    Screen currentScreen;

    //Intro Screen
    void PlayerName()
    {
        currentScreen = Screen.Intro;
        Terminal.WriteLine("Enter thou Name");
    }

    //Main Menu Screen
    void ShowMenu(string plyrname)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Hello "+ plyrname);
        Terminal.WriteLine("How much of a NOOOBB are You");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Total Newb");
        Terminal.WriteLine("2. Bot Level Noob");
        Terminal.WriteLine("3. Experienced Noob");
        Terminal.WriteLine("4. High class Noob");
        Terminal.WriteLine("");

    }

    //Start Game Level
    void Level()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You Have choosen " + level);
    }

    //Just take input
    void OnUserInput(string input)
    {
        EvalInput(input);
    }

    private void EvalInput(string input)
    {
        if (currentScreen == Screen.Intro && !string.IsNullOrWhiteSpace(input) && input != "menu")
        {
            plyrname = input;
            ShowMenu(plyrname);
        }
        else if (input == "menu" && !string.IsNullOrWhiteSpace(plyrname))
        {
            ShowMenu(plyrname);
        }
        else if (currentScreen == Screen.MainMenu)
        {
            LevelChoice(input);
        }
    }

    private void LevelChoice(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                Level();
                break;
            case "2":
                level = 2;
                Level();
                break;
            case "3":
                level = 3;
                Level();
                break;
            case "4":
                level = 4;
                Level();
                break;
            default:
                currentScreen = Screen.MainMenu;
                Terminal.WriteLine("Wrong Level");
                break;
        }
    }

    void Start()
    {
        PlayerName();
    }
}
