using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    public InputField usernameRegisterInput;
    public InputField passwordRegisterInput;
    public InputField repeatPasswordInput;
    public InputField emailInput;
    public Button registerButton;
    public Text resultTextRegister;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(() =>
        {
            if (passwordRegisterInput.text == repeatPasswordInput.text)
            {
<<<<<<< HEAD:Cubeventure/Assets/Scripts/MainMenu/RegisterScript.cs
                StartCoroutine(Web.instance.Register(usernameRegisterInput.text, passwordRegisterInput.text, emailInput.text));
                usernameRegisterInput.text = "";
                //passwordRegisterInput.text = "";
                //repeatPasswordInput.text = "";
                emailInput.text = "";
                //resultTextRegister.text = "";
                //resultTextregister.text = ("Registration successful");
=======
                StartCoroutine(Main.Instance.Web.Register(usernameRegisterInput.text, passwordRegisterInput.text, emailInput.text));
                resultTextregister.text = ("Registration successful");
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel):Cubeventure/Assets/Scripts/RegisterScript.cs
            } else
            {
                resultTextRegister.text = ("Hesla sa nezhoduju");
            }
            
        });
    }
}
