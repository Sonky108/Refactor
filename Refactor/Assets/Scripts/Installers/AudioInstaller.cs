using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller<AudioInstaller>
{   
    [SerializeField]
    private AudioController.Settings settings;
      
    public override void InstallBindings()
    {
        Debug.Log("Install");
        Container.BindInterfacesAndSelfTo<AudioController>().AsSingle().WithArguments(settings);
        // Container.BindInterfacesAndSelfTo<AudioController>().AsCached();
    }
}
