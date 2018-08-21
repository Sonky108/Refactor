using System;
using UnityEngine;
using Zenject;

namespace DaftCode.Refactor
{
    public class ManInstaller : MonoInstaller<ManInstaller>
    {            
        [SerializeField]
        private Settings settings;

        public override void InstallBindings()
        {
            Debug.Log("Install");
            Container.Bind<Man>().AsSingle()
                .WithArguments(settings.mouth);
            //Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();

            Container.BindInterfacesAndSelfTo<ManInputController>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public SpriteRenderer mouth;
        }
    }
}
