using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour
{
    private bool logged;
    public string name;
    public string pw;
    public static LoginHandler instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            //check loginu
            Destroy(gameObject);
        }
    }

    public bool IsUserLoggedIn()
    {
        return logged;
    }

    public void SetLoginDetails(string name, string pw)
    {
        this.name = name;
        this.pw = pw;
        logged = true;
    }

}
