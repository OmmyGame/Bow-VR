using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float Damage;
    private void OnCollisionEnter(Collision collision)
    {
        Damageable d = collision.collider.GetComponent<Damageable>();
        if (d)
        {
            d.DealDamage(Damage);
        }
    }
}
