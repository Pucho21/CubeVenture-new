using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Web : MonoBehaviour
{
    public static Web instance;
    public Text resultTextLogin;
    public Text resultTextRegistration;
    EventSystem system;

    private void Awake()
    {
        instance = this;
        system = EventSystem.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        

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

    public IEnumerator SetLevelHighscore(int totalScore)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        form.AddField("levelID", UserInfoHolder.instance.selectedLevel.levelID);
        form.AddField("updatedScore", totalScore);
        form.AddField("updatedStars", UserInfoHolder.instance.selectedLevel.stars);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/updateLevelHighscore", form))
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

                //callback function  to pass result
            }
        }
    }
//**************************************************************************************************************************************
    public IEnumerator UnlockNewLevel()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        form.AddField("levelID", UserInfoHolder.instance.selectedLevel.levelID + 1);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/createNewLevel", form))
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

                //callback function  to pass result
            }
        }
    }
//********************************************************************************************************************************************
    public IEnumerator Leaderboard()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/getLeaderboard", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully retrieved scores!");
                string contents = www.downloadHandler.text;
                using (StringReader reader = new StringReader(contents))
                {
                    string line;
                    string username = "";
                    string maxLevel = "";
                    string totalScore;
                    int pom = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        pom++;
                        if (pom == 1) username = line;
                        else if (pom == 2) maxLevel = line;
                        else
                        {
                            totalScore = line;
                            pom = 0;
                            LeaderboardHandler.instance.CreateLBRecord(username, maxLevel, totalScore);
                        }                  
                    }
                }

                    //Show results as text
                    Debug.Log(www.downloadHandler.text);

                //callback function  to pass result
            }
        }
    }

    //***********************************************************************************************************************************************
    public IEnumerator GetUserCoins(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/getUsers", form))
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
                UserInfoHolder.instance.SetCoins(int.Parse(www.downloadHandler.text));

                //callback function  to pass result
            }
        }
    }
//***********************************************************************************************************************************************
    public IEnumerator Login(string username, string password)// -1 = user neexistuje, 0 = zle udaje, 1 = success
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/login", form))
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
                if(www.downloadHandler.text.Equals("-1"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {
                    resultTextLogin.text = "Username does not exist";
                    //neexistuje pouzivatel
                    

                } else if (www.downloadHandler.text.Equals("0"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {
                    resultTextLogin.text = "Wrong credentials";
                    //ficurka keby nieco, prehodit alebo tak

                }
                else // logged in correctly 
                {
                    resultTextLogin.text = "Login successful";
                    UserInfoHolder.instance.SetID(www.downloadHandler.text);
                    //UserInfoHolder.instance.SetCoins(int.Parse(www.downloadHandler.text));
                    //ShowUserItems();
                    AudioManager.instance.PlaySound("click");
                    yield return new WaitForSeconds(2);
                    UIManager.instance.introScreen();
                }

            }
        }
    }
//***********************************************************************************************************************************************
    public IEnumerator Register(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);
        form.AddField("loginEmail", email);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/register", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                resultTextRegistration.text = "chyba";
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Equals("-2"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {

                    resultTextRegistration.text = "Email is not valid";

                }
                else if (www.downloadHandler.text.Equals("-1"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {

                    resultTextRegistration.text = "Username is not valid";

                }
                else if (www.downloadHandler.text.Equals("0"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {

                    resultTextRegistration.text = "Password must be between 5 and 20 characters long!";

                } else if (www.downloadHandler.text.Equals("-3"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {

                    resultTextRegistration.text = "Credentials already used!";

                }
                else // logged in correctly 
                {
                    resultTextRegistration.text = "Registration was successful";

                    //AudioManager.instance.PlaySound("click");
                    yield return new WaitForSeconds(2);
                    UIManager.instance.LoginUserScreen();
                }

            }
        }
    }

    //***********************************************************************************************************************************************
    public IEnumerator BuyItem(string itemID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        form.AddField("itemID", itemID);

        //Debug.Log("posielam udaje: " + UserInfoHolder.instance.userID + " a " + itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/buyItem", form))
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


//***********************************************************************************************************************************************
    public IEnumerator UserLevelStats()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/getUserLevelStats", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //TODO 1 = levelid, 2 = stars, 3 = score
                string jsonArray = www.downloadHandler.text;

                int pom = 1;
                string parseString = "";
                string levelID = "";
                string stars = "";
                string score = "";

                for (int i = 0; i < jsonArray.Length; i++)
                {
                    char c = Convert.ToChar(jsonArray.Substring(i, 1));
                    if (Char.IsDigit(c))
                    {
                        parseString = parseString + c;
                    }
                    else if (!parseString.Equals(""))
                    {
                        if (pom == 1)
                        {
                            levelID = parseString;
                            pom++;
                        } else if (pom == 2)
                        {
                            stars = parseString;
                            pom++;
                        } else
                        {
                            score = parseString;
                            pom = 1;
                            LevelSelectPanel.instance.SetLevelStats(levelID, stars, score);
                        }
                        parseString = "";
                    }
                }
                //Show results as text
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

    //***********************************************************************************************************************************************
    public IEnumerator UpdateCoins()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        form.AddField("updatedCoins", UserInfoHolder.instance.coins);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/updateCoins", form))
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

    //***********************************************************************************************************************************************
    public IEnumerator GetItemsIDs(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure_laravel/public/getItemsIDs", form))
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
                string jsonArray = www.downloadHandler.text; 

                string pomID = "";
                List<int> itemIDs = new List<int>();             
                for(int i = 0; i < jsonArray.Length; i++)
                {
                    char c = Convert.ToChar(jsonArray.Substring(i, 1));
                    if (Char.IsDigit(c))
                    {
                        pomID = pomID + c;
                    } else if(!pomID.Equals(""))
                    {
                        //Debug.Log("purchased itemID: " + pomID);
                        itemIDs.Add(int.Parse(pomID));
                        pomID = "";                
                    }
                }
                ShopHandler.instance.SetUnlockedItemsDB(itemIDs);

                //callback function  to pass result
            }
        }
    }


}
