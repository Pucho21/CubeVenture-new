using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPanel : MonoBehaviour
{
    public static LevelSelectPanel instance;
    public Transform levelContent;
    public LevelSelectButton selected;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(Web.instance.UserLevelStats());
    }

    public void OpenDifficultyPanel(LevelSelectButton selected)
    {
        this.selected = selected;
    }

    public void EasySelected()
    {
        selected.SelectLevel(1);
        Debug.Log("hrame lahku");
    }

    public void MediumSelected()
    {
        selected.SelectLevel(2);
        Debug.Log("hrame strednu");
    }

    public void HardSelected()
    {
        selected.SelectLevel(3);
        Debug.Log("hrame tvrdu");
    }

    public void SetLevelStats(string levelID, string stars, string score)
    {
        Debug.Log("level id: " + levelID + " stars: " + stars + " score: " + score);
        levelContent.GetChild(int.Parse(levelID)-1).GetComponent<LevelSelectButton>().SetStarsAndScore(int.Parse(stars), int.Parse(score));
    }

}
