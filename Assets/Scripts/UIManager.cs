using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;
using Ommy.Prefs;
using BNG;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public GameObject losePanel,gamePanel;
    public TMP_Text highScoreTitle;
    public TMP_Text losePanelHighScore;
    public Image healthBar;
    public GameObject loading;
    public SceneLoader sceneLoader;
    public void SetHealth(float health)
    {
        healthBar.fillAmount=health;
    }
    public void RestartButton()
    {
        sceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        //GameManager.Instance.LoadScene(SceneManager.GetActiveScene().name,0,true);
    }
    public void HomeButton()
    {
        sceneLoader.LoadScene("MainMenu");

        //SceneManager.LoadScene(0);
    }
    public void GameOver(bool newRecord)
    {   
        losePanel.SetActive(true);
        gamePanel.SetActive(false);
        losePanelHighScore.text=GamePreference.HighScore.ToString();
        highScoreTitle.text= newRecord? "New High Score" : "High Score";
        highScoreTitle.color= newRecord? Color.green : Color.white;
        if(newRecord)highScoreTitle.GetComponent<DOTweenAnimation>().DOPlay();
        //loading.SetActive(true);
    }
}
