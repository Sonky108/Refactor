using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class ScreenPressedSignal
{

}

public class ScreenReleasedSignal
{

}

public class ControllerUI : IInitializable
{
    private readonly SignalBus signalBus;

    [Header("Buttons")]

    private PointerController screen;

    private void BindButtons()
    {
        screen.onPointerDown.AddListener(OnScreenDown);

        screen.onPointerUp.AddListener(OnScreenUp);
    }

    private void UnbindButtons()
    {
        screen.onPointerDown.RemoveListeners();

        screen.onPointerUp.RemoveListeners();
    }

    private void OnScreenUp()
    {
        signalBus.Fire(new ScreenReleasedSignal());
    }

    private void OnScreenDown()
    {
        signalBus.Fire(new ScreenPressedSignal());
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