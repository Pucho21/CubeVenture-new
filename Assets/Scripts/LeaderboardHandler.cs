using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardHandler : MonoBehaviour
{
    public static LeaderboardHandler instance;
    public GameObject leaderboardRecordGO;
    public Transform leaderboardContent;

    private void Awake()
    {
        instance = this;
        StartCoroutine(Web.instance.Leaderboard());
    }

    public void CreateLBRecord(string username, string MaxLevel, string totalScore)
    {
        GameObject record = Instantiate(leaderboardRecordGO, leaderboardContent);
        record.transform.GetChild(0).GetComponent<Text>().text = username;
        record.transform.GetChild(1).GetComponent<Text>().text = "Level " + MaxLevel;
        record.transform.GetChild(2).GetComponent<Text>().text = totalScore;
    }

}
