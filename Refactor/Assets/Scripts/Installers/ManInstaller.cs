using System;
using UnityEngine;
using Zenject;

public class ManInstaller : MonoInstaller<ManInstaller>
{            
    [SerializeField]
    private Settings settings;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ManController>().AsSingle()
            .WithArguments(settings.mouth);
    }

    [Serializable]
    public class Settings
    {
        public SpriteRenderer mouth;
    }
}
