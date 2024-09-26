using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRotate : MonoBehaviour
{
    public bool useRotation;
    public bool useX;
    public bool useY;
    public bool useZ;
    public Transform targetY,targetX,targetZ;
    public Vector3 offSet;
    public float speed = 10.0f;
    Vector3 idealEuler;
    private void Start() 
    {
        Application.targetFrameRate=72;    
    }
    public void Update()
    {
        //transform.position = Vector3.Lerp(transform.position,targetX.position,speed*Time.deltaTime);
        // transform.position = new Vector3
        // (
        //     useX? (targetX.position+offSet).x : transform.position.x,
        //     useY? (targetY.position+offSet).y : transform.position.y,
        //     useZ? (targetZ.position+offSet).z : transform.position.z
        // );
        transform.position = Vector3.Lerp(transform.position, new Vector3
        (
            useX? (targetX.position+offSet).x : transform.position.x,
            useY? (targetY.position+offSet).y : transform.position.y,
            useZ? (targetZ.position+offSet).z : transform.position.z
        ), speed*Time.deltaTime);
    }
    void LateUpdate()
    {
        if(!useRotation)return;
        idealEuler.x = transform.eulerAngles.x;
        idealEuler.z = transform.eulerAngles.z;
        idealEuler.y = targetY.eulerAngles.y;
        Quaternion qr  = Quaternion.Euler(idealEuler);
        transform.rotation = Quaternion.Lerp(transform.rotation, qr, Time.deltaTime * 5);     
    }
}
