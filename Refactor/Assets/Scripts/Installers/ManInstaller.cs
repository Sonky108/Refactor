using System;
using UnityEngine;
using Zenject;

public class ManInstaller : MonoInstaller<ManInstaller>
{            
    [SerializeField]
    private Settings settings;

    public override void InstallBindings()
    {
        Debug.Log("Install");
        //Container.Bind<ManController>();
        Container.Bind<IMan>().To<Man>().AsSingle()
            .WithArguments(settings.mouth);
    }

    [Serializable]
    public class Settings
    {
        public SpriteRenderer mouth;
    }
}
