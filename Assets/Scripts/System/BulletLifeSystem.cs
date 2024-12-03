using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class BulletLifeSystem : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private GameObject defaultPrefabBullet;
    [SerializeField] private GameObject miniPrefabBullet;
    [Inject] DiContainer diContainer;
    [Inject] EffectSystem effectSystem;

    private List<GameObject> bulletsList = new List<GameObject>();

    private GameObject bull;
    private Transform transformPrefab;

    public void AddProjectile()
    {
        bull = diContainer.InstantiatePrefab(defaultPrefabBullet);
        bull.transform.position = spawnPosition.transform.position;
        bull.transform.rotation = spawnPosition.transform.rotation;

        bulletsList.Add(bull);
    }

    private void AddProjectile(int count)
    {
        for (int i = 0; i < count; i++)
        {
            bull = diContainer.InstantiatePrefab(miniPrefabBullet);
            bull.transform.position = transformPrefab.transform.position + Vector3.up * i * 0.3f;
            bull.transform.rotation = transformPrefab.transform.rotation;

            bulletsList.Add(bull);
        }
    }

    public void RemoveProjectile(GameObject bullObject, int sharePart)
    {
        if(bullObject != null)
        {
            for(int i = 0; i < bulletsList.Count; i++)
            {
                if (bulletsList[i] == bullObject)
                {
                    if(sharePart > 0)
                    {
                        transformPrefab = bulletsList[i].transform;
                        AddProjectile(sharePart);
                    }

                    effectSystem.startEffect(bulletsList[i], "Boom");

                    bulletsList.Remove(bulletsList[i]);
                    Destroy(bullObject);
                }
            }
        }
       
    }
}
