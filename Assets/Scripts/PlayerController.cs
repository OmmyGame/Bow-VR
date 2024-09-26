using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

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
    public BloodScreenEffect bloodScreenEffect;
    public Transform face;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public void TakeDamage(float damage)
    {
        bloodScreenEffect.ShowBloodScreen();
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
        GameManager.OnDie?.Invoke();
        bloodScreenEffect.bloodScreenImage.enabled=false;
    }
    private void OnTriggerStay(Collider other) 
    {
        print("player Trigger stay with "+other.name);
        if(other.gameObject.CompareTag("DeadZone"))
        {
            TakeDamage(0.5f);
        }     
    }
}
