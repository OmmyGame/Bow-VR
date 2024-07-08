using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

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
    public Image healthBar;
    public GameObject loading;
    public void SetHealth(float health)
    {
        healthBar.fillAmount=health;
    }

    public void GameOver()
    {   
        loading.SetActive(true);
    }
}
