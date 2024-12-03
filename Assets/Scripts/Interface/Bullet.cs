using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet:MonoBehaviour
{
    [Inject] protected BulletLifeSystem bulletLifeSystem;

    [SerializeField] protected float moveSpeed = 15f;
    [SerializeField] protected float TimeToDetonation = 15f;
    [SerializeField] protected bool isShare = false;
    [SerializeField] protected int shareParts = 0;

    protected virtual void Move()
    {
        Debug.Log("ERROR");
    }

    protected virtual void Detonation()
    {
        Debug.Log("ERROR");
    }

}
