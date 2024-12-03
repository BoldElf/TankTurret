using UnityEngine;
using Zenject;

public class UISystemInstaller : MonoInstaller
{
    [SerializeField] private UISystem uISystemInstaller;

    public override void InstallBindings()
    {
        Container.Bind<UISystem>().FromInstance(uISystemInstaller).AsSingle();
        Container.QueueForInject(uISystemInstaller);
    }
}