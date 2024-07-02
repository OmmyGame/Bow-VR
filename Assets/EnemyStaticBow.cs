using System.Collections;
using System.Collections.Generic;
using BNG;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Interactions;

public class EnemyStaticBow : MonoBehaviour
{
    [Header("inputs")]
    public bool isDrownOutArrow = false;
    public float drownValue;
    public bool isHoldingArrow;
    [Space(10)]
    public Transform arrowParent;
    public ParentConstraint knockParentConstraint;
    public Arrow_Custom holdedArrow;
    public Arrow_Custom ArrowPrefab;
    public float shootingForce;
    public Transform target;
    public Transform aimLocker;
    public GameObject nonFunctionalArrow;
    public StateMachineEventListner stateMachineEventListner;
    public void OnEnable()
    {
        stateMachineEventListner.onEventInvoke+=OnStateMachineEventInvoke;
    }
    public void OnStateMachineEventInvoke(StateMachineEventType stateMachineEventType)
    {
        switch (stateMachineEventType)
        {
            case StateMachineEventType.Release:
                nonFunctionalArrow?.SetActive(false);
                break;
            case StateMachineEventType.Charging:
                break;
            case StateMachineEventType.Pick:
                nonFunctionalArrow?.SetActive(true);
                break;
        }
    }
    public void Update()
    {
        //knockParentConstraint.weight=drownValue;
        if (isHoldingArrow)
        {
            InstantiateArrow();
        }
        if (!isHoldingArrow)
        {
            ShootArrow();
        }
        // if(Input.GetKeyDown(KeyCode.I))
        // {
        //     InstantiateArrow();
        // }
        // if(Input.GetKeyDown(KeyCode.S))
        // {
        //     ShootArrow();
        // }
        //AimLockers();
        RotateTowardsOpponent();
    }
    public void RotateTowardsOpponent()
    {
        // Calculate the direction to the target
        Vector3 targetDirection = target.position - transform.position;

        // Zero out the Y component to get a direction parallel to the XZ plane
        targetDirection.y = 0;

        // If the target direction is zero (i.e., the object is exactly above or below the target), return to avoid NaN rotations
        if (targetDirection == Vector3.zero)
            return;

        // Compute the rotation needed to look in the target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // Smoothly interpolate towards the target rotation only around the Y-axis
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Slerp(currentRotation, Quaternion.Euler(0, targetRotation.eulerAngles.y, 0), Time.deltaTime * 2.0f);

        // Apply the new rotation
        transform.rotation = newRotation;
    }
    public void AimLockers()
    {
        aimLocker.LookAt(target);
    }
    public void ShootArrow()
    {
        if (holdedArrow != null)
        {
            holdedArrow.ShootArrow(holdedArrow.transform.forward * shootingForce);
            holdedArrow = null;
        }
    }
    public void InstantiateArrow()
    {
        if (!holdedArrow)
        {
            holdedArrow = Instantiate(ArrowPrefab, arrowParent);
            //holdedArrow.InitArrow();
        }
    }
}
