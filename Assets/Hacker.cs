using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //config data
    string[] level1Passwords = { "books", "asile", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "corruption", "mayor", "court", "judge", "bailiff", "magistrate" };

    //game state
    int level;
    enum Screen { MainMenu, Password, Win}
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Select target");
        Terminal.WriteLine("Press 1 for the local school");
        Terminal.WriteLine("Press 2 for city hall");
        Terminal.WriteLine("Press 3 for the state capital");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }

        
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[0];
                break;
            case 2:
                password = level2Passwords[0];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            Terminal.WriteLine("WELL DONE");
        }
        else
        {
            Terminal.WriteLine("Incorrect");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
