using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void GameOver()
    {
        Debug.Log("Game Over");
        UIManager.instance.GameOver();
        GameManager.Instance.LoadScene("BowController",3f,true);
    }
}
