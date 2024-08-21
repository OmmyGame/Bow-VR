using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public abstract class Agent : MonoBehaviour, IAgent
{
    public float speed = 1.0f;
    public Damageable damageable;
    public float damage = 10.0f;
    public float chaseDistance;
    public float attackDistance;
    public bool attacking;
    public bool isDie;
    public float health;
    public Transform target;
    // /public AnimationCurve animationAmount;
    public StateMachine stateMachine;
    private void Start()
    {
        stateMachine=new StateMachine(this);
        stateMachine.Init(stateMachine.chaseState);
    }
    public void Init(Transform target)
    {
        this.target=target;
    }
    private void Update()
    {
        stateMachine.Update();
        StateAssigner();
    }
    public void StateAssigner()
    {
        if (Vector3.Distance(target.position, transform.position) < attackDistance)
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }
        else if (Vector3.Distance(target.position, transform.position) < chaseDistance)
        {
            stateMachine.ChangeState(stateMachine.chaseState);
        }
    }
    public virtual void Attack()
    {
        if (isDie) return;
        PlayerController.Instance.TakeDamage(damage);
        Destroy(this.gameObject);
    }
    public void OnDamage(Single damage)
    {
        health-=damage;
        if(health<=0)
        {
            OnDie();
        }
    }
    public void OnDie()
    {
        isDie = true;
        ScoreManager.instance.AddScore(1);
        //Destroy(gameObject);
    }

    public virtual void Idle()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Petrolling()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Flee()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Chase()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Defend()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Damage()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Death()
    {
        throw new System.NotImplementedException();
    }
}
public interface IAgent
{
    public void Idle();
    public void Petrolling();
    public void Attack();
    public void Flee();
    public void Chase();
    public void Defend();
    public void Damage();
    public void Death();
}