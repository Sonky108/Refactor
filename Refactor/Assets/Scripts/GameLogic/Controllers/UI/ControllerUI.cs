using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class ScreenReleasedSignal
{

}

public class ControllerUI : IInitializable
{
    private readonly SignalBus signalBus;

    private CompositeDisposable disposables = new CompositeDisposable();

    private PointerController screen;

    private void BindButtons()
    {
        screen.PointerUp().Subscribe(x => OnScreenUp()).AddTo(disposables);
    }

    private void UnbindButtons()
    {
        disposables.Clear();
    }

    private void OnScreenUp()
    {
        signalBus.Fire(new ScreenReleasedSignal());
    }

    private void OnScreenDown()
    {

    }

    public ControllerUI(SignalBus signalBus, Settings settings)
    {
        this.signalBus = signalBus;
        screen = settings.screen;
    }

    public void Initialize()
    {
        UnbindButtons();
        BindButtons();
    }

    [Serializable]
    public class Settings
    {
        public PointerController screen;
    }
}