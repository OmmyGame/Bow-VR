using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Agent
{
    public override void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.face.position, speed * Time.deltaTime);
        transform.LookAt(PlayerController.Instance.face);
    }
    public override void Damage()
    {
    }
    public override void Death()
    {
    }
}
