using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int score = 0;

    public int highScore = 0;

    public GameObject goScore;

    public GameObject goHighScore;

    private Text scoreText;
    private Text highScoreText;

    //
    public String highScoreToTenTable;

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore",highScore);
        }
        //
        if (PlayerPrefs.HasKey("HighScoreTopTenTable"))
        {
            highScoreToTenTable = PlayerPrefs.GetString("HighScoreTopTenTable");
        }
        else
        {
            PlayerPrefs.SetString("HighScoreTopTenTable", "-, 0; -, 0;-, 0;-, 0;-, 0;-, 0;-, 0;-, 0;-, 0;-, 0;-, 0;");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        goScore = GameObject.Find("txtScore");
        scoreText= goScore.GetComponent<Text>();

        goHighScore = GameObject.Find("txtHighScore");
        highScoreText = goHighScore.GetComponent<Text>();
        highScoreText.text = "HIGH-SCORE:" + highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString("#,0");
    }


    public void TRY_TO_SET_HIGHSCORE(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            PlayerPrefs.SetInt("HighScore",highScore);
            //highScoreText.text = "HIGH SCORE: " + highScore.ToString("#,0");
            highScoreText.text = "HIGH SCORE: " + highScore.ToString();
        }

    }
}
