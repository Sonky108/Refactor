using UnityEngine;
using Zenject;

public class UIControllerInstaller : MonoInstaller<UIControllerInstaller>
{
    public ControllerUI.Settings settings;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<ControllerUI>().AsSingle().WithArguments(settings);
    }
}