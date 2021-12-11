using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoHolder : MonoBehaviour
{
    public static UserInfoHolder instance;
    public Level selectedLevel;

    public int coins;
    private bool logged;
    [HideInInspector] public bool goToLvlSelect;
    public string userID { get; private set; }
    public string name;
    public string pw;
    public string hatID;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //check loginu
            Destroy(gameObject);
        }
    }

    public bool IsUserLoggedIn()
    {
        return logged;
    }

    public void SetCredentials(string name, string pw)
    {
        this.name = name;
        this.pw = pw;
        logged = true;
    }

    public void SetID(string id)
    {
        userID = id;
        StartCoroutine(Web.instance.GetUserCoins(userID));
        Debug.Log("user id je: " + userID);
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
    }

    private void GetUserInfoDB()
    {
        //dotaz na DB
    }

    //kupime item, posleme string itemu, odpocitame coins

    public void CoinsUpdateDB(int price)
    {
        coins -= price;
        StartCoroutine(Web.instance.UpdateCoins());
        //ulozit do DB ze item je kupeny
        //prepisat coins hraca v DB
    }

    public void CollectedCoinsDB(int collectedCoins)
    {
        coins += collectedCoins;
        StartCoroutine(Web.instance.UpdateCoins());
    }

    public void SetHatID(string hatID)
    {
        this.hatID = hatID;
    }

    public class Level
    {
        public int levelID, highscore, stars, difficulty;

        public Level(int levelID, int highscore, int stars, int difficulty)
        {
            this.difficulty = difficulty;
            this.levelID = levelID;
            this.highscore = highscore;
            this.stars = stars;
        }
    }

}
