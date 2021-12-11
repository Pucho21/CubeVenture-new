using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;

    private void Awake()
    {
                
    }

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {

            StartCoroutine(Main.Instance.Web.Login(usernameInput.text, passwordInput.text));
            LoginHandler.instance.SetLoginDetails(usernameInput.text, passwordInput.text);
        });

        

    }


}
