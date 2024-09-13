using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Grabber grabberR, grabberL;
    public Grabber currentHand;
    public Grabbable sword,bow;
    public Grabbable currentWeapon;
    private void Update() 
    {
        if(InputBridge.Instance.RightGripDown)
        {
            ChangeWeapon(sword);
        }
        if(InputBridge.Instance.LeftGripDown)
        {
            ChangeWeapon(bow);
        }
        if(InputBridge.Instance.LeftGripDown)
        {
            //ChangeHand(grabberL);
        }
        if(InputBridge.Instance.RightGripDown)
        {
            //ChangeHand(grabberR);
        }

    }
    public void ChangeWeapon(Grabbable weapone)
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeapon=weapone;
        currentWeapon.gameObject.SetActive(true);
        //currentWeapon.GrabItem(currentHand);
        //currentHand.HeldGrabbable=null;
        grabberL.TryRelease();
        grabberR.TryRelease();
        if(currentWeapon==bow)
        {
            currentHand=grabberL;
        }
        else
        {
            currentHand=grabberR;
        }
        //currentHand.GrabGrabbable(currentWeapon);
        currentHand.GrabGrabbable(currentWeapon);
    }
    public void ChangeHand(Grabber hand)
    {
        if(currentHand==hand)return;
        currentHand=hand;
        ChangeWeapon(currentWeapon);
    }
}
