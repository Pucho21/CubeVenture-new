<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public int collectedStarsCount = 0;
    [HideInInspector] public int collectedCoinsCount = 0;
    [HideInInspector] public int enemiesKilledCount;
    private float gameTimeElapsed;

    [Space]
    public GameObject pausePanel;
    public GameObject endPanel;
    bool gamePaused;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTimeElapsed += Time.deltaTime;
        InGameUIPanel.instance.UpdateTimeText(Mathf.FloorToInt(gameTimeElapsed));

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }

    }

    public void CoinCollected()
    {
        collectedCoinsCount++;
        InGameUIPanel.instance.UpdateCoinsCountText();
    }

    public void StarCollected()
    {
        collectedStarsCount++;
        InGameUIPanel.instance.UpdateStarsCountText();
    }
    public void EnemyKilled()
    {
        enemiesKilledCount++;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gamePaused = false;
        AudioManager.instance.PlaySound("click");
    }

    public void EndGame()
    {
        endPanel.GetComponent<EndPanel>().SetEndPanelValues(collectedStarsCount,enemiesKilledCount,collectedCoinsCount,Mathf.RoundToInt(gameTimeElapsed));
    }

    public void NextLevel()
    {
        GoToMainMenu();
        UserInfoHolder.instance.goToLvlSelect = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        FadeScreen.instance.FadeToScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlaySound("click");
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        FadeScreen.instance.FadeToScene(0);
        AudioManager.instance.ChangeMusic();
        AudioManager.instance.PlaySound("click");
        UserInfoHolder.instance.goToLvlSelect = false;
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int starsCount;
    [HideInInspector]public int collectedStarsCount = 0;

    [Space]
    public int coinsCount;
    [HideInInspector] public int collectedCoinsCount = 0;

    public GameObject pausePanel;
    bool gamePaused;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gamePaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene("MainMenu");
    }



    public void CoinCollected()
    {
        collectedCoinsCount++;
        InGameUIPanel.instance.UpdateCoinsCountText();
    }

    public void StarCollected()
    {
        collectedStarsCount++;
        InGameUIPanel.instance.UpdateStarsCountText();
    }
}
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel)
