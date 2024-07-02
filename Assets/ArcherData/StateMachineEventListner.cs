//Ommy
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEventListner : MonoBehaviour
{
    public Action<StateMachineEventType> onEventInvoke;
    public void OnEventInvoke(StateMachineEventType stateMachineEventType)
    {
        onEventInvoke.Invoke(stateMachineEventType);
        switch (stateMachineEventType)
        {
            case StateMachineEventType.Release:
                break;
            case StateMachineEventType.Charging:
                break;
            case StateMachineEventType.Pick:
                break;
        }
    }
}
public enum StateMachineEventType
{
    Release, Charging, Pick
}