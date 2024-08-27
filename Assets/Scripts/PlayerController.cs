using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public Transform face;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UIManager.instance.SetHealth(currentHealth / maxHealth);
    }
    public void Die()
    {
        GamePlayManager.Instance.GameOver();
    }
}
