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
    public event Action screenDownListeners;
    public event Action screenUpListeners;

    readonly SignalBus signalBus;

    [Header("Buttons")]

    private PointerController screen;

   /* public void Awake()
    {
        UnbindButtons();
        BindButtons();
    }*/

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
       // screenUpListeners?.Invoke();
    }

    private void OnScreenDown()
    {
        signalBus.Fire(new ScreenPressedSignal());
       // screenDownListeners?.Invoke();
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