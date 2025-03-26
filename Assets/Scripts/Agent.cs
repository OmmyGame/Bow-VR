using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public float speed = 1.0f;
    public Damageable damageable;
    public float damage = 10.0f;
    public float chaseDistance;
    public float attackDistance;
    public bool isDie;
    public Transform target;
    public void Init(Transform target)
    {
        this.target=target;
    }
    private void Update()
    {
        StateAssigner();
    }
    public virtual void StateAssigner()
    {
        if (Vector3.Distance(target.position, transform.position) < attackDistance)
        {
           Attack();
        }
        else if (Vector3.Distance(target.position, transform.position) < chaseDistance)
        {
           Chase();
        }
    }
    public abstract void Chase();
    public abstract void Death();
    public abstract void OnDamage(Single damage);
    public virtual void Attack()
    {
        if (isDie) return;
        PlayerController.Instance.TakeDamage(damage);
        Destroy(this.gameObject);
    }
}