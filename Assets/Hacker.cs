using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration data
    string returntomenu = "Enter 2wice to return to Main Menu";
    string[] level1Anagram = { "Smit", "Nikunj", "Ritu", "Jayesh" };
    string[] level2Anagram = { "Anti Mage","Arc Warden","Bloodseeker","Bounty Hunter","Broodmother", "Clinks","Drow Ranger","Ember Spirit","Faceless Void","Gyrocopter","Juggernaut","Lone Druid","Luna","Medusa","Meepo","Mirana","Monkey King","Morphling","Naga Siren","Nyx Assassin","Pangolier","Phantom Assassin","Phantom Lancer","Razor","Riki","Shadow Fiend", "Slark", "Sniper","Spectre","Templar Assassin","Terrorblade","Troll Warlord","Ursa","Vengeful Spirit","Venomancer","Viper","Weaver"};
    string[] level3Anagram = { "Abaddon","Alchemist","Axe","Beastmaster","Brewmaster","Bristleback","Centaur Warrunner","Chaos Knight","Clockwerk","Doom","Dragon Knight","Earth Spirit", "EarthShaker","Elder Titan","Husker","Io","Kunkka","Legion Commander","Lifestealer","Lycan","Magnus","Mars","Night Stalker","Omniknight","Phoenix","Pudge","Sand King","Slardar","Spirit Breaker","Sven","Tidehunter","Timbersaw","Tiny","Treat Protector","Tusk","Underlord","Undying","Wraith King"};
    string[] level4Anagram = { "Ancient Apparition","Bane","Batrider","Chen","Crystal Maiden","Dark Seer","Dark Willow","Dazzle","Death Prophet","Disrupter","Enchantress","Enigma","Grimstroke","Invoker","Jakiro","Keeper of the Light","Leshrac","Lich","Lina","Lion","Natures Prophet","Necrophos","Ogre Magi","Oracle","Outworld Devourer","Puck","Pugna", "Queen of Pain","Rubick","Shadow Demon","Shadow Shaman","Silencer","Skywrath Mage","Storm Spirit","Techies","Tinker","Visage","Warlock","Windranger","Winter Wyvern","Witch Doctor", "Zeus" };


    //Game States
    int level;
    bool mmflag;
    string plyrname;
    string anagram;
    enum Screen { Intro, MainMenu, Guessing, WinLoss }
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

    void LevelChoice(string input)
    {
        int index;
        index = CheckForInt(input);
        switch (index)
        {
            case 1:
                level = index;
                anagram = level1Anagram[Random.Range(0, level1Anagram.Length)];
                EnterLevel();
                break;
            case 2:
                level = index;
                anagram = level2Anagram[Random.Range(0, level2Anagram.Length)];
                EnterLevel();
                break;
            case 3:
                level = index;
                anagram = level3Anagram[Random.Range(0, level3Anagram.Length)];
                EnterLevel();
                break;
            case 4:
                level = index;
                anagram = level4Anagram[Random.Range(0, level4Anagram.Length)];
                EnterLevel();
                break;
            default:
                ShowMenu();
                Terminal.WriteLine("Wrong Level");
                Debug.LogError("Invalid Level Number");
                break;
        }
    }//Menu Choices

    int CheckForInt(string input)
    {
        int index;
        if (int.TryParse(input, out index))
        {
            index = int.Parse(input);
        }
        else
        {
            ShowMenu();
            Terminal.WriteLine("Please selecr valid number from choices");
        }

        return index;
    }//Checks whether Input is Int type

    //Start Game Level
    void EnterLevel()
    {
        currentScreen = Screen.Guessing;
        Terminal.ClearScreen();
        Terminal.WriteLine(returntomenu);
        Terminal.WriteLine("Guess the word : HINT[" +anagram.Anagram()+"]");
    }


    //Anagram Checker
    void CheckAnagram(string pass)
    {
        if (pass == anagram)
        {
            DisplayWinScreen();
        }
        else
        {
            DisplayLossScreen();
        }
    }

    void DisplayLossScreen()
    {
        Debug.LogError("Wrong Answer");
        Terminal.WriteLine(@"
     %%% %%%%%%%         |#|
  %%%% %%%%%%%%%%%      |#|####
%%%%% %         %%%    |#|=#####
%%%% %   @    @   %%   | | ==####
%%%% % (_  ()  )  %%  | |    ===##
  %%% %  \_   _| %%   | |       =##
   %%%% %  u^u  %%   | |         ==#
    %%%% %%%%%%%     | |           V
     Reaper awaits Your Noobness
        ");
        Terminal.WriteLine(returntomenu);
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.WinLoss;
        Terminal.ClearScreen();
        RewardScreen();
    }

    void RewardScreen()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
       _,     _   _     ,_
   .-'` /     \'-'/     \ `'-.
  /    |      |   |      |    \
 ;      \_  _/     \_  _/      ;
|         ``         ``         |
|          Won Level 1          |
 ;    .-.   .-.   .-.   .-.    ;
  \  (   '.'   \ /   '.'   )  /
   '-.;         V         ;.-'
                ");
                break;
            case 2:
                Terminal.WriteLine(@"
       _,     _   _     ,_
   .-'` /     \'-'/     \ `'-.
  /    |      |   |      |    \
 ;      \_  _/     \_  _/      ;
|         ``         ``         |
|          Won Level 2          |
 ;    .-.   .-.   .-.   .-.    ;
  \  (   '.'   \ /   '.'   )  /
   '-.;         V         ;.-'
                ");
                break;
            case 3:
                Terminal.WriteLine(@"
       _,     _   _     ,_
   .-'` /     \'-'/     \ `'-.
  /    |      |   |      |    \
 ;      \_  _/     \_  _/      ;
|         ``         ``         |
|          Won Level 3          |
 ;    .-.   .-.   .-.   .-.    ;
  \  (   '.'   \ /   '.'   )  /
   '-.;         V         ;.-'
                "); break;
            case 4:
                Terminal.WriteLine(@"
    ________________
   /.,------------,.\
  ///  .=------->__|\\
  \\\   `------.   .//
   `\\`--...._  `;//'
     `\\.-,___;.//'
       `\\-..-//'
         `\\//'
           ''
                "); break;
        }
        Terminal.WriteLine(returntomenu);
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
        else if (input == "" && (currentScreen != Screen.Intro || currentScreen != Screen.MainMenu))
        {
            BackToMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            LevelChoice(input);
        }
        else if (currentScreen == Screen.Guessing)
        {
            CheckAnagram(input);
        }
    }

    private void BackToMenu()
    {
        if (mmflag == false)
        {
            mmflag = true;
        }
        else
        {
            ShowMenu();
            mmflag = false;
        }
    }

    private void EvalPlayerName(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || input == "menu")
        {
            PlayerName();
            Terminal.WriteLine("Get a Better Name");
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
