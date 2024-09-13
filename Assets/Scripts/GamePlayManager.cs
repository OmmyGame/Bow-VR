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
        Debug.Log("Game Over");
        UIManager.instance.GameOver();
    }
}
