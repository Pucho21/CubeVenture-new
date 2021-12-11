using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Web : MonoBehaviour
{
    public Text resultTextLogin;
    EventSystem system;


    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");

        }
    }

    public IEnumerator getUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/cubeventure/getusers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);

                //or retrieve results as binary data
                Debug.Log(www.downloadHandler.data);
            }
        }
    }

    public IEnumerator Login(string username, string password)// -1 = user neexistuje, 0 = zle udaje, 1 = success
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                resultTextLogin.text = "chyba";
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                if(www.downloadHandler.text.Equals("1"))// -1 = user neexistuje, 0 = zle udaje, 1 = success
                {
                    resultTextLogin.text = "Login successful";
                    yield return new WaitForSeconds(2);
                    UIManager.instance.introScreen();

                } else if (www.downloadHandler.text.Equals("0"))// -1 = user neexistuje, 0 = zle udaje, 1 = success
                {
                    resultTextLogin.text = "Wrong creditals";
                    //ficurka keby nieco, prehodit alebo tak

                }
                else // -1 = user neexistuje, 0 = zle udaje, 1 = success
                {
                    resultTextLogin.text = "Username does not exist";
                    //neexistuje pouzivatel

                }

            }
        }
    }

    public IEnumerator Register(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);
        form.AddField("loginEmail", email);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);

            }
        }
    }


}
