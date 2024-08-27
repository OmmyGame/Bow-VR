using System;
using System.Collections;
using System.Collections.Generic;
using Ommy.Animation;
using UnityEngine;

public class EnemyAI : Agent
{
    public StateMachineEventListner stateMachineEventListner;
    public Animator animator;
    private void OnEnable() {
        stateMachineEventListner.OnEventInvoke.AddListener(OnAnimationEvent);
    }
    public override void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.face.position, speed * Time.deltaTime);
        transform.LookAt(PlayerController.Instance.face);
    }
    public void OnAnimationEvent(StateMachineEventType stateMachineEventType)
    {
        switch (stateMachineEventType)
        {
            case StateMachineEventType.Attack:
                PlayerController.Instance.TakeDamage(damage);
            break;
        }
    }
    public void OnDamage(Single damage)
    {
        OnDie();
    }
    public void OnDie()
    {
        stateMachine.ChangeState(stateMachine.deathState);
        isDie = true;
        ScoreManager.instance.AddScore(1);
        Destroy(gameObject,1.5f);
    }
    public override void Damage()
    {
        
    }
    public override void Death()
    {
        animator.SetTrigger("Die");
    }
    public override void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
