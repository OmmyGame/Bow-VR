using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DrawOutArrowStateMachine : StateMachineBehaviour
{
  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    
  //}

  //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  public float drawTime,releaseTime;
  public bool isDrownOutArrow = false;
  public float drownValue;
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    drownValue = DrawValue(stateInfo);
    if (stateInfo.normalizedTime >= 0.25f && !isDrownOutArrow)
    {
      isDrownOutArrow = true;
      //Debug.Log("ustaad");
    }
    animator.GetComponent<EnemyBowSystem>().isDrownOutArrow=isDrownOutArrow;
    animator.GetComponent<EnemyBowSystem>().drownValue=drownValue;
  }
  public float DrawValue(AnimatorStateInfo stateInfo)
  {
    //Debug.Log("normalizedTime "+ stateInfo.normalizedTime);
    float normalizedTime = stateInfo.normalizedTime%1;
    if (normalizedTime >= drawTime && normalizedTime < releaseTime)
    {
      return (normalizedTime - drawTime) / (releaseTime - drawTime);
    }
    return 0f; // or any default value you prefer for out-of-range cases
  }
  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    isDrownOutArrow=false;
  }

  // OnStateMove is called right after Animator.OnAnimatorMove()
  override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    // Implement code that processes and affects root motion
  }

  // OnStateIK is called right after Animator.OnAnimatorIK()
  override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    // Implement code that sets up animation IK (inverse kinematics)
  }
}
