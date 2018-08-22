using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<ScreenReleasedSignal>();
    }
}