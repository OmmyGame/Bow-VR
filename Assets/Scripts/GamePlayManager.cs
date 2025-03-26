using System.Collections;
using System.Collections.Generic;
using BNG;
using Ommy.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void Start()
    {
        AudioManager.Instance?.StartGame();
    }
    public WeaponManager weaponManager;

    public void GameOver()
    {
        bool newRecord=ScoreManager.instance.hasNewRecord;
        Debug.Log("Game Over");
        if(newRecord) AudioManager.Instance.PlaySFX(SFX.reward);
        else AudioManager.Instance.PlaySFX(SFX.fail);
        UIManager.instance.GameOver(newRecord);
    }
}
