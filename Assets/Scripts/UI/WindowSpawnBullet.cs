using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowSpawnBullet : MonoBehaviour
{
    [Inject] UISystem uiSystem;

    public void pressButton()
    {
        uiSystem.AddBullet();
    }
}
