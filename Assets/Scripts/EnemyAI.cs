using System;
using System.Collections;
using System.Collections.Generic;
using Ommy.Animation;
using Ommy.Audio;
using UnityEngine;

public class EnemyAI : Agent
{
    public StateMachineEventListner stateMachineEventListner;
    public Animator animator;
    public AudioSource voice;
    public void Start() 
    {
        voice.Play();
    }
    private void OnEnable() 
    {
        stateMachineEventListner.OnEventInvoke.AddListener(OnAnimationEvent);
    }
    public override void Chase()
    {
        if(!voice.isPlaying)voice.Play();
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
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
    public override void OnDamage(Single damage)
    {
        OnDie();
    }
    public void OnDie()
    {
        voice.Stop();
        isDie = true;
        ScoreManager.instance.AddScore(1);
        AudioManager.Instance.PlaySFX(SFX.Kill);
        Destroy(gameObject,1.5f);
    }
    public override void Death()
    {
        animator.SetTrigger("Die");
    }
    public override void Attack()
    {
        voice.Stop();
        AudioManager.Instance?.PlaySFX(SFX.Attack,0.5f);
        animator.SetTrigger("Attack");
    }
}
