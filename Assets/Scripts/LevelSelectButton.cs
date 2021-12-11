using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    //public int levelID;
    private int highScore;
    public Text levelText;
    public Text scoreText;
    private int stars;

    private void Awake()
    { 
        GetComponent<Button>().onClick.AddListener(()=>OnClicked());
    }

    public void OnClicked()
    {
        LevelSelectPanel.instance.OpenDifficultyPanel(this);
    }

    public void SelectLevel(int difficulty)
    {
        UserInfoHolder.instance.selectedLevel = new UserInfoHolder.Level(1 + transform.GetSiblingIndex(), highScore, stars, difficulty);
        FadeScreen.instance.FadeToScene(transform.GetSiblingIndex() + 1);
        AudioManager.instance.ChangeMusic();
        //SceneManager.LoadScene("Level" + (transform.GetSiblingIndex() + 1));
    }

    //*********************************************************************************************************

    public void SetStarsAndScore(int stars, int score)
    {
        this.stars = stars;
        highScore = score;
        scoreText.text = "Best: " + score;
        switch (stars)
        {
            case 1:
                {
                    transform.GetChild(2).GetComponent<Image>().color = Color.white;
                    transform.GetChild(3).GetComponent<Image>().color = new Color32(0,0,0,120);
                    transform.GetChild(4).GetComponent<Image>().color = new Color32(0,0,0,120);
                    break;                                      
                }                                               
            case 2:                                             
                {                                               
                    transform.GetChild(2).GetComponent<Image>().color = Color.white;
                    transform.GetChild(3).GetComponent<Image>().color = Color.white;
                    transform.GetChild(4).GetComponent<Image>().color = new Color32(0,0,0,120);
                    break;                                      
                }                                               
            case 3:                                             
                {                                               
                    transform.GetChild(2).GetComponent<Image>().color = Color.white;
                    transform.GetChild(3).GetComponent<Image>().color = Color.white;
                    transform.GetChild(4).GetComponent<Image>().color = Color.white;
                    break;
                }
            default:
                transform.GetChild(2).GetComponent<Image>().color = new Color32(0,0,0,120);
                transform.GetChild(3).GetComponent<Image>().color = new Color32(0,0,0,120);
                transform.GetChild(4).GetComponent<Image>().color = new Color32(0,0,0,120);
                break;
        }
        GetComponent<Button>().enabled = true;
        GetComponent<Image>().color = Color.white;
        levelText.text = "Level " + (transform.GetSiblingIndex() + 1);

//***********************************************************************************************************

    }

}
