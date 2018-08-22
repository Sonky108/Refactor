using UnityEngine;
using Zenject;

public class EmotionsInstaller : MonoInstaller<EmotionsInstaller>
{
    [SerializeField]
    private EmotionsRegistry.Settings settings;

    public override void InstallBindings()
    {
        Container.Bind<IEmotionsRegistry>()
            .To<EmotionsRegistry>()
            .AsSingle()
            .WithArguments(settings.emotions);

        Container.DeclareSignal<EmotionChangedSignal>();
        Container.BindSignal<EmotionChangedSignal>().ToMethod<IManController>(x => x.ChangeEmotion).FromResolveAll();
    }
}