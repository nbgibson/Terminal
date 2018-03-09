using UnityEngine;

public class Hacker : MonoBehaviour {

    //config data
    const string menuHint = "Enter menu at any time to return";
    string[] level1Passwords = { "books", "asile", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "corruption", "mayor", "court", "judge", "bailiff", "magistrate" };
    string[] level3Passwords = { "lottery", "governor", "supremecourt", "legislature", "principality", "university" };

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
        else if(input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Please close the tab");
            Application.Quit();
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"
                );
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("The city is yours");
                Terminal.WriteLine(@"
   ______________       
   | |   |   |  |   \\# /_____/ \ 
   |            |    \# |+ ++|  | 
 ~~|    (~~~~~) |~~~~~#~| H  |_ |~
   |    ( ||| ) |     # ~~~~~~    
   ~~~~~~~~~~~~~________/  /_____                                  
                ");
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine("Uhoh, here come the feds!");
                Terminal.WriteLine(@"
      /\ 
     /<>\ 
    /=  =\
   /      \
  / /\  /\ \
 / /  \/  \ \                     
                ");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
