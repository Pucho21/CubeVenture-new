using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{    
    public Text levelText;

    [Space]
    public int scorePerStar =1000;
    public Image star1;
    public Image star2;
    public Image star3;


    [Header("ExtraPointTexts")]
    public int pointsPerEnemy = 50;
    public Text enemyScoreText;
    [Space]
    public int pointsPerCoin = 10;
    public Text coinsScoreText;
    [Space]
    [Header("1s = -1point")]
    public int maxTimePoints = 500; 
    public Text timeText;


    [Header("Score")]
    public Text totalScoreText;
    public Image newHSImage;
    public Text highScoreText;

    [Header("Difficulty multiplier")]
    [Range(1,3)] public float easyMultiplier;
    [Range(1,3)] public float mediumMultiplier;
    [Range(1,3)] public float hardMultiplier;
    public Text difficultyText;


    public void SetEndPanelValues(int stars,int enemiesKilled,int coinsCollected, int time)
    {
        EnableStars(stars);
        enemyScoreText.text = "" + enemiesKilled * pointsPerEnemy;
        coinsScoreText.text = "" + coinsCollected * pointsPerCoin;
        float timeScore = maxTimePoints - time;
        if (timeScore < 0) {
            timeScore = 0;
        }
        timeText.text = "" + Mathf.RoundToInt(timeScore);
        float totalScore = enemiesKilled * pointsPerEnemy + coinsCollected * pointsPerCoin + timeScore + scorePerStar * stars + 1;

        if (UserInfoHolder.instance.selectedLevel.difficulty == 1) {
            totalScore = totalScore * easyMultiplier;
            difficultyText.text = "easy";
        }
        else if (UserInfoHolder.instance.selectedLevel.difficulty == 2) {
            totalScore = totalScore * mediumMultiplier;
            difficultyText.text = "medium";
        }
        else {
            totalScore = totalScore * hardMultiplier;
            difficultyText.text = "hard";
        }
        levelText.text = "Level " + UserInfoHolder.instance.selectedLevel.levelID + "\n Completed!";
        totalScoreText.text = "Total \n" + Mathf.RoundToInt(totalScore);
        highScoreText.text = "Highscore \n" + UserInfoHolder.instance.selectedLevel.highscore;
        gameObject.SetActive(true);
        UserInfoHolder.instance.CollectedCoinsDB(coinsCollected);
        if(UserInfoHolder.instance.selectedLevel.highscore == 0 && UserInfoHolder.instance.selectedLevel.levelID < 3) StartCoroutine(Web.instance.UnlockNewLevel());
        if (totalScore > UserInfoHolder.instance.selectedLevel.highscore)
        {
            newHSImage.enabled = true;
            UserInfoHolder.instance.selectedLevel.highscore = Mathf.RoundToInt(totalScore);
            Debug.Log("setujem score: " + totalScore);
            if (stars > UserInfoHolder.instance.selectedLevel.stars)
            {
                UserInfoHolder.instance.selectedLevel.stars = stars;
            }
            StartCoroutine(Web.instance.SetLevelHighscore(Mathf.RoundToInt(totalScore)));
        } else
        {
            newHSImage.enabled = false;
            Debug.Log(UserInfoHolder.instance.selectedLevel.highscore + " > " + totalScore);
        }
    }


    void EnableStars(int starsCount)
    {
        switch(starsCount)
        {
            case 0:
                star1.color = new Color32(0,0,0,120);
                star2.color = new Color32(0,0,0,120);
                star3.color = new Color32(0,0,0,120);
                star1.transform.GetChild(0).gameObject.SetActive(false);
                star2.transform.GetChild(0).gameObject.SetActive(false);
                star3.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 1:
                star1.color = Color.white;
                star2.color = new Color32(0, 0, 0, 120);
                star3.color = new Color32(0, 0, 0, 120);
                star1.transform.GetChild(0).gameObject.SetActive(true);
                star2.transform.GetChild(0).gameObject.SetActive(false);
                star3.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 2:
                star1.color = Color.white;
                star2.color = Color.white;
                star3.color = new Color32(0, 0, 0, 120);
                star1.transform.GetChild(0).gameObject.SetActive(true);
                star2.transform.GetChild(0).gameObject.SetActive(true);
                star3.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 3:
                star1.color = Color.white;
                star2.color = Color.white;
                star3.color = Color.white;
                star1.transform.GetChild(0).gameObject.SetActive(true);
                star2.transform.GetChild(0).gameObject.SetActive(true);
                star3.transform.GetChild(0).gameObject.SetActive(true);
                break;

        }
    }
}
