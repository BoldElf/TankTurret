using UnityEngine;
using Zenject;

public class BulletLifeInstaller : MonoInstaller
{
    [SerializeField] private BulletLifeSystem bulletLifeSystem;

    public override void InstallBindings()
    {
        Container.Bind<BulletLifeSystem>().FromInstance(bulletLifeSystem).AsSingle();
        Container.QueueForInject(bulletLifeSystem);
    }
}