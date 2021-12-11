<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject introUI;
    public GameObject loginUI;
    public GameObject mainMenuUI;
    public GameObject loginUserUI;
    public GameObject registerUserUI;
    public GameObject shopUI;
    public GameObject settingsUI;
    public GameObject scoreboardUI;
    public GameObject levelSelectorUI;
    public GameObject difficultyUI;


    public GameObject shop3DCube;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        if (UserInfoHolder.instance.IsUserLoggedIn())
        {
            if (UserInfoHolder.instance.goToLvlSelect)
            {
                LevelSelectorScreen();
            }
            else
            {
                MainMenu();
            }
        }

    }

    public void clearScreen()
    {
        loginUI.SetActive(false);
        registerUserUI.SetActive(false);
        mainMenuUI.SetActive(false);
        introUI.SetActive(false);
        loginUserUI.SetActive(false);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
        scoreboardUI.SetActive(false);
        levelSelectorUI.SetActive(false);
        difficultyUI.SetActive(false);
        shop3DCube.SetActive(false);
        
        //userDataUI.SetActive(false);
        //preloadni tooooo

    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        clearScreen();
        loginUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void SettingsScreen()
    {
        clearScreen();
        settingsUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void DifficultyScreen()
    {
        clearScreen();
        difficultyUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void LevelSelectorScreen()
    {
        clearScreen();
        levelSelectorUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void ScoreboardScreen()
    {
        clearScreen();
        scoreboardUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void ShopScreen()
    {
        clearScreen();
        shop3DCube.SetActive(true);
        shopUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void RegisterUserScreen() // Register button
    {
        clearScreen();
        registerUserUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }
    public void LoginUserScreen() //Back button
    {
        clearScreen();
        loginUserUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void MainMenu()
    {
        clearScreen();
        mainMenuUI.SetActive(true);
        AudioManager.instance.PlaySound("click");
    }

    public void introScreen()
    {
        clearScreen();
        introUI.SetActive(true);
    }


}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject introUI;
    public GameObject loginUI;
    public GameObject mainMenuUI;
    public GameObject loginUserUI;
    public GameObject registerUserUI;
    //public GameObject userDataUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        if (LoginHandler.instance.IsUserLoggedIn())
        {
            MainMenu();
        }
    }

    public void clearScreen()
    {
        loginUI.SetActive(false);
        registerUserUI.SetActive(false);
        mainMenuUI.SetActive(false);
        introUI.SetActive(false);
        loginUserUI.SetActive(false);
        //userDataUI.SetActive(false);

    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        clearScreen();
        loginUI.SetActive(true);
    }
    public void RegisterUserScreen() // Register button
    {
        clearScreen();
        registerUserUI.SetActive(true);
    }
    public void LoginUserScreen() //Back button
    {
        clearScreen();
        loginUserUI.SetActive(true);
    }

    public void MainMenu()
    {
        clearScreen();
        mainMenuUI.SetActive(true);
    }

    public void introScreen()
    {
        clearScreen();
        introUI.SetActive(true);
    }

    /*
    public void UserDataScreen()
    {
        clearScreen();
        userDataUI.SetActive(true);
    }
    

    public void ScoreboardScreen()
    {
        clearScreen();
        scoreMenuUI.SetActive(true);
    }
    */

}
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel)
