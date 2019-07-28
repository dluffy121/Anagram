using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration data
    const string returntomenu = "Enter 2wice to return to Main Menu";
    string[] level1Anagram = { "Anti Mage","Arc Warden","Bloodseeker","Bounty Hunter","Broodmother", "Clinks","Drow Ranger","Ember Spirit","Faceless Void","Gyrocopter","Juggernaut","Lone Druid","Luna","Medusa","Meepo","Mirana","Monkey King","Morphling","Naga Siren","Nyx Assassin","Pangolier","Phantom Assassin","Phantom Lancer","Razor","Riki","Shadow Fiend", "Slark", "Sniper","Spectre","Templar Assassin","Terrorblade","Troll Warlord","Ursa","Vengeful Spirit","Venomancer","Viper","Weaver"};
    string[] level2Anagram = { "Abaddon","Alchemist","Axe","Beastmaster","Brewmaster","Bristleback","Centaur Warrunner","Chaos Knight","Clockwerk","Doom","Dragon Knight","Earth Spirit", "EarthShaker","Elder Titan","Husker","Io","Kunkka","Legion Commander","Lifestealer","Lycan","Magnus","Mars","Night Stalker","Omniknight","Phoenix","Pudge","Sand King","Slardar","Spirit Breaker","Sven","Tidehunter","Timbersaw","Tiny","Treat Protector","Tusk","Underlord","Undying","Wraith King"};
    string[] level3Anagram = { "Ancient Apparition","Bane","Batrider","Chen","Crystal Maiden","Dark Seer","Dark Willow","Dazzle","Death Prophet","Disrupter","Enchantress","Enigma","Grimstroke","Invoker","Jakiro","Keeper of the Light","Leshrac","Lich","Lina","Lion","Natures Prophet","Necrophos","Ogre Magi","Oracle","Outworld Devourer","Puck","Pugna", "Queen of Pain","Rubick","Shadow Demon","Shadow Shaman","Silencer","Skywrath Mage","Storm Spirit","Techies","Tinker","Visage","Warlock","Windranger","Winter Wyvern","Witch Doctor", "Zeus" };
    string[] lossascii = 
    {
        @"
███╗   ██╗ ██████╗  ██████╗ ██████╗ 
████╗  ██║██╔═══██╗██╔═══██╗██╔══██╗
██╔██╗ ██║██║   ██║██║   ██║██████╔╝
██║╚██╗██║██║   ██║██║   ██║██╔══██╗
██║ ╚████║╚██████╔╝╚██████╔╝██████╔╝
╚═╝  ╚═══╝ ╚═════╝  ╚═════╝ ╚═════╝",
        @"
███████╗ ██████╗ ██████╗            
██╔════╝██╔═══██╗██╔══██╗           
█████╗  ██║   ██║██████╔╝           
██╔══╝  ██║   ██║██╔══██╗           
██║     ╚██████╔╝██║  ██║           
╚═╝      ╚═════╝ ╚═╝  ╚═╝ 
        ",
        @"
██╗     ██╗███████╗███████╗         
██║     ██║██╔════╝██╔════╝         
██║     ██║█████╗  █████╗           
██║     ██║██╔══╝  ██╔══╝           
███████╗██║██║     ███████╗   
        ",
    };

    //Game States
    int level;
    int i;
    bool mmflag;
    string plyrname;
    string anagram;
    enum Screen { Intro, MainMenu, Guessing, Win ,Loss, End}
    Screen currentScreen;
    Screen previousScreen;

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
        Terminal.WriteLine("3. High class Noob");
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
            Terminal.WriteLine("Please select valid number from choices");
        }

        return index;
    }//Checks whether LevelChoice is Int type

    //Start Game Level
    void EnterLevel()
    {
        currentScreen = Screen.Guessing;
        Terminal.ClearScreen();
        Terminal.WriteLine("Guess the Hero : HINT[" +anagram.Anagram()+"]");
        Terminal.WriteLine(returntomenu);
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
        currentScreen = Screen.Loss;
        Debug.LogError("Wrong Answer");
        LossMessage();
    }

    void LossMessage()
    {
        while (mmflag == true)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine(lossascii[i]);
            mmflag = false;
            i++;
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        WinMessage();
    }

    void WinMessage()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
 ▄▄▄        ▄████  ██▓
▒████▄     ██▒ ▀█▒▓██▒
▒██  ▀█▄  ▒██░▄▄▄░▒██▒
░██▄▄▄▄██ ░▓█  ██▓░██░    Pro
 ▓█   ▓██▒░▒▓███▀▒░██░
 ▒▒   ▓▒█░ ░▒   ▒ ░▓  
  ▒   ▒▒ ░  ░   ░  ▒ ░
  ░   ▒   ░ ░   ░  ▒ ░
      ░  ░      ░  ░  
                ");
                break;
            case 2:
                Terminal.WriteLine(@"
  ██████ ▄▄▄█████▓ ██▀███  
▒██    ▒ ▓  ██▒ ▓▒▓██ ▒ ██▒
░ ▓██▄   ▒ ▓██░ ▒░▓██ ░▄█ ▒
  ▒   ██▒░ ▓██▓ ░ ▒██▀▀█▄     Pro
▒██████▒▒  ▒██▒ ░ ░██▓ ▒██▒
▒ ▒▓▒ ▒ ░  ▒ ░░   ░ ▒▓ ░▒▓░
░ ░▒  ░ ░    ░      ░▒ ░ ▒░
░  ░  ░    ░        ░░   ░ 
      ░              ░     
                "); break;
            case 3:
                Terminal.WriteLine(@"
 ██▓ ███▄    █ ▄▄▄█████▓
▓██▒ ██ ▀█   █ ▓  ██▒ ▓▒
▒██▒▓██  ▀█ ██▒▒ ▓██░ ▒░
░██░▓██▒  ▐▌██▒░ ▓██▓ ░    Pro
░██░▒██░   ▓██░  ▒██▒ ░ 
░▓  ░ ▒░   ▒ ▒   ▒ ░░   
 ▒ ░░ ░░   ░ ▒░    ░    
 ▒ ░   ░   ░ ░   ░      
 ░           ░          
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
    void EvalInput(string input)
    {
        if (currentScreen == Screen.Intro)
        {
            EvalPlayerName(input);
        }
        else if (input == "" && currentScreen != Screen.Intro)
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

    void BackToMenu()
    {
        if (mmflag == false && currentScreen==Screen.Loss && i<3)
        {
            mmflag = true;
            LossMessage();
            previousScreen = currentScreen;
        }
        else if(mmflag==false)
        {
            mmflag = true;
            previousScreen = currentScreen;
        }
        else if(mmflag==true && previousScreen != currentScreen)
        {
            mmflag = false;
        }
        else
        {
            ShowMenu();
            mmflag = false;
        }
    }

    void EvalPlayerName(string input)
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
