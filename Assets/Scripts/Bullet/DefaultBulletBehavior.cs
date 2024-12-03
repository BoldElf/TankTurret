using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultBulletBehavior : Bullet
{
    private float timer;

    private void FixedUpdate()
    {
        if(timer < TimeToDetonation * Time.deltaTime)
        {
            timer += Time.deltaTime;
            Move();
        }
        else
        {
            Detonation();
        }
    }
 
    protected override void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    protected override void Detonation()
    {
        bulletLifeSystem.RemoveProjectile(gameObject, shareParts);
    }
}
