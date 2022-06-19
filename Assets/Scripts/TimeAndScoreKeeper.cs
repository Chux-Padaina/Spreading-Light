using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAndScoreKeeper : MonoBehaviour
{
    public float timeCount;
    private float startTime;
    private int timeScore;

    private static TimeAndScoreKeeper _instance;

    public TextMeshProUGUI scoreText;

    public GameManager gameManager;

    void Awake()
    {
        timeCount = PlayerPrefs.GetFloat("timeSaver", 0f); 
        startTime = Time.time - timeCount;
        if(startTime < 0f)
        {
            startTime = 0f;
        }
    }

    private void Update()
    {
        timeCount = Time.time - startTime;
        timeScore = Mathf.FloorToInt(timeCount);
        if (gameManager.health==0)
        {
            PlayerPrefs.SetFloat("timeSaver", timeScore);
        }
        scoreText.text=timeScore.ToString();
    }

}



