using System.Collections;
using System.Collections.Generic;
using Ommy.Prefs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gamePlaySceneIndex=1;
    public GameObject manuPanel;
    public TMP_Text highScore;
    private void Start() 
    {
        UpdateScore(GamePreference.HighScore);    
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(gamePlaySceneIndex);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void UpdateScore(int Score)
    {
        highScore.text=Score.ToString();
    }
}
