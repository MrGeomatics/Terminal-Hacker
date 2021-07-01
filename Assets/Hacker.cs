using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type 'menu' at any time.";
    string[] level1Passwords = { "book", "shelf", "librarian", "silence", "reading" };
    string[] level2Passwords = { "mp5", "glock-17", "baton", "handcuff", "prison" };
    string[] level3Passwords = { "vaccine", "COVID-19", "scientist", "zombies", "uroboros" };
    int lives = 3;
    string password;
    int level;
    enum Screen { MainMenu, Password, Win, Lose};
    Screen currentScreen;
    
    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("           PIP BOY TERMINAL");
        Terminal.WriteLine("Be careful you have only 3 lives.");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1. Library");
        Terminal.WriteLine("2. Police Station");
        Terminal.WriteLine("3. Bio Lab");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            lives = 3;
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
        if (input == "1" || input == "2" || input == "3")
        {
            int a = int.Parse(input);
            level = a;
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please choose a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level!");
            Terminal.WriteLine(menuHint);
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        
        if (level == 1)
        {
            Terminal.WriteLine("Hacking into Library...");
        }
        else if (level == 2)
        {
            Terminal.WriteLine("Hacking into Police Station... ");
        }
        else
        {
            Terminal.WriteLine("Hacking into Bio Lab...");
        }
        Terminal.WriteLine("Enter your password hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Please enter your password: ");
    }

    private void SetRandomPassword()
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

        else if(input != password)
        {
                lives--;                              
                AskForPassword();
                Terminal.WriteLine("You have " + lives + " lives left.");
            if (lives == 0)
                {
                    DisplayLoseScreen();                
                }                   
        }     
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"Dobby says Hello!
   _____
  /     \
/- (*) |*)\
|/\.  _>/\|
    \__/    |\
   _| |_   \-/
  /|\__|\  //
 |/|   |\\//
");
                break;
            case 2:
                Terminal.WriteLine(@"FBI OPEN UP!!
     _.-^^---....,,__       
 _--                 --_  
<                       >)
|          BOOM          | 
 \._                   ./  
    ```--. . , ; .--'''       
          | |   |             
       .-=||  | |=-.  
");
                break;
            case 3:
                Terminal.WriteLine(@"Recycle please :)
   ________   ________
  /_______/  |_____/  \
 |   \   /        /   /
  \   \         \/   /
   \  /          \__/_
    \/ ____    /\
      /  \    /  \
     /\   \  /   /
       \___\/___/");
                break;
        }
        
    }

    void DisplayLoseScreen()
    {
        currentScreen = Screen.Lose;
        Terminal.ClearScreen();
        Terminal.WriteLine(@"YOU ARE DEAD NOW!!
             ___          
            /   \\        
       /\\ | . . \\       
      ///\\|     ||       
     //   \\ ___//\       
    //     \\      \      
   //      |\\      |     
           | \\  \   \    
           |  \\  \   \");
        Terminal.WriteLine(menuHint);
    }
    
    
    void Update()
    {
        int index = Random.Range(0, level1Passwords.Length);
        print(index);
        int index2 = Random.Range(0, level2Passwords.Length);
        print(index2);
        int index3 = Random.Range(0, level3Passwords.Length);
        print(index3);
    }
}
