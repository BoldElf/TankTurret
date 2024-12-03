using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UISystem : MonoBehaviour
{
    [Inject] BulletLifeSystem bulletLifeSystem;

    public void AddBullet()
    {
        bulletLifeSystem.AddProjectile();
    }

    private void OffUI()
    {

    }

    private void OnUI()
    {

    }
}
