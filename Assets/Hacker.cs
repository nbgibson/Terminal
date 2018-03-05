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
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[2];
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
        Terminal.WriteLine("You have chosen level " + level);
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
