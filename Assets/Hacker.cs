using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration data
    string[] level1Passwords = { "Smit", "Nikunj", "Ritu", "Jayesh" };
    string[] level2Passwords = { "Juggernaut", "ShadowFiend", "Slark", "Clinks"};
    string[] level3Passwords = { "Husker", "LegionCommander", "EarthShaker", "Axe" };
    string[] level4Passwords = { "StormSpirit", "QueenOfPain", "Zeus", "Lion" };


    //Game States
    int level;
    string plyrname;
    string password;
    enum Screen { Intro, MainMenu, Password, Game, WinLoss }
    Screen currentScreen;

    //Intro Screen
    void PlayerName()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Intro;
        Terminal.WriteLine("Enter thou Name");
    }

    //Main Menu Screen
    void ShowMenu()
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

    //Menu Choice
    private void LevelChoice(string input)
    {
        int index = int.Parse(input);
        switch (index)
        {
            case 1:
                level = index;
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                Level();
                break;
            case 2:
                level = index;
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                Level();
                break;
            case 3:
                level = index;
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                Level();
                break;
            case 4:
                level = index;
                password = level4Passwords[Random.Range(0, level4Passwords.Length)];
                Level();
                break;
            default:
                ShowMenu();
                Terminal.WriteLine("Wrong Level");
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    //Start Game Level
    void Level()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter Password");
    }

    //Password Checker
    void CheckPassword(string pass)
    {
        if (pass == password)
        {
            Terminal.WriteLine("Get started Noob");
        }
        else
        {
            ShowMenu();
            Debug.LogError("Wrong Password");
            Terminal.WriteLine("Sry Pros not allowed");
        }
    }

    //Just take input
    void OnUserInput(string input)
    {
        EvalInput(input);
    }

    //Check Input given at every stage
    private void EvalInput(string input)
    {
        if (currentScreen == Screen.Intro)
        {
            EvalPlayerName(input);
        }
        else if (input == "menu" && !string.IsNullOrWhiteSpace(plyrname))
        {
            ShowMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            LevelChoice(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void EvalPlayerName(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || input == "menu")
        {
            PlayerName();
            Terminal.WriteLine("Get Better Name");
        }
        else
        {
            plyrname = input;
            ShowMenu();
        }
    }

    void Start()
    {
        PlayerName();
    }
}
