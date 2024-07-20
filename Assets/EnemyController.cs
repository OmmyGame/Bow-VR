using System.Collections;
using System.Collections.Generic;
using BNG;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public Damageable damageable;
    public float damage = 10.0f;
    public float attackDistance;
    public bool attacking;
    public bool isDie;
    // /public AnimationCurve animationAmount;
    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.face.position, speed * Time.deltaTime);
        transform.LookAt(PlayerController.Instance.face);
        Attack();
    }
    public void Attack()
    {
        if (Vector3.Distance(transform.position, PlayerController.Instance.face.position) < attackDistance)
        {
            if(isDie)return;
            if(!damageable.IsDestroyed())
            PlayerController.Instance.TakeDamage(damage);
            Destroy(this.gameObject);
            //damageable.DealDamage(100);
        }
    }
    public void OnDamage()
    {

    }
    public void OnDie()
    {
        isDie=true;
        ScoreManager.instance.AddScore(1);
        //Destroy(gameObject);
    }
}
