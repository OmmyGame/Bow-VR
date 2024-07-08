using System.Collections;
using System.Collections.Generic;
using Ommy.Prefs;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public TMP_Text highScoreTxt;
    public TMP_Text scoreTxt;
    public int score=0;
    private void Start() 
    {
        SetHighScore(GamePreference.HighScore);    
    }
    public void AddScore(int score)
    {
        score += 1;
        scoreTxt.text = score.ToString();
        if(score>GamePreference.HighScore)
        {
            SetHighScore(score);
        }
    }
    void SetHighScore(int score)
    {
        highScoreTxt.text=score.ToString();
        GamePreference.HighScore=score;
    }
}
