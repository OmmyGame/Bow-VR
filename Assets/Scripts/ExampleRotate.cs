using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRotate : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    public float speed = 10.0f;
    Vector3 idealEuler;
    public void Update()
    {
        transform.position = target.position+offSet;
    }
    void LateUpdate()
    {
        idealEuler.x = transform.eulerAngles.x;
        idealEuler.z = transform.eulerAngles.z;
        idealEuler.y = target.eulerAngles.y;
        Quaternion qr  = Quaternion.Euler(idealEuler);
        transform.rotation = Quaternion.Lerp(transform.rotation, qr, Time.deltaTime * 5);     
    }
}
