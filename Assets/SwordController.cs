using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float attackForceThreshold;
    public float damage;
    
    private Vector3 previousPosition;
    private float velocityMagnitude;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate velocity based on the change in position
        Vector3 movement = transform.position - previousPosition;
        velocityMagnitude = movement.magnitude / Time.deltaTime;
        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Check if the manually calculated velocity exceeds the threshold
        if (velocityMagnitude > attackForceThreshold)
        {
            Damageable d = collision.GetComponent<Damageable>();
            if (d)
            {
                d.DealDamage(damage);
            }
        }
    }
}
