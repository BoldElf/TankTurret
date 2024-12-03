using UnityEngine;
using Zenject;

public class EffectSystemInstaller : MonoInstaller
{
    [SerializeField] private EffectSystem effectSystem;

    public override void InstallBindings()
    {
        Container.Bind<EffectSystem>().FromInstance(effectSystem).AsSingle();
        Container.QueueForInject(effectSystem);
    }
}