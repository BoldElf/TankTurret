using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EffectSystem : MonoBehaviour
{
    [SerializeField] private GameObject prefabExplosion;
    [Inject] DiContainer diContainer;

    private List<GameObject> effectList = new List<GameObject>();

    private  GameObject currentEffect;
    public void startEffect(GameObject spawnPosition, string type)
    {
        if(type == "Boom")
        {
            currentEffect = Instantiate(prefabExplosion);
            currentEffect.transform.position = spawnPosition.transform.position;

            effectList.Add(currentEffect);
        }
    }
}
