using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsSingle();

        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<ScreenPressedSignal>();
        Container.DeclareSignal<ScreenReleasedSignal>();
        Container.DeclareSignal<EmotionChangedSignal>();

        Container.BindSignal<ScreenReleasedSignal>().ToMethod<GameManager>(x => x.OnScreenPressed).FromResolve();
    
        Container.BindSignal<EmotionChangedSignal>().ToMethod<IMan>(x => x.ChangeEmotion).FromResolveAll();
    }
}