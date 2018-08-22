using UnityEngine;
using Zenject;

public class EmotionsInstaller : MonoInstaller<EmotionsInstaller>
{
    [SerializeField]
    private EmotionsRegistry.Settings settings;

    public override void InstallBindings()
    {
        Debug.Log("Install");
        Container.Bind<IEmotionsRegistry>()
            .To<EmotionsRegistry>()
            .AsSingle()
            .WithArguments(settings.emotions);
    }
}