using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviourSingleton<ControllerUI>
{
    public event Action screenDownListeners;
    public event Action screenUpListeners;

    [Header("Buttons")]

    [SerializeField]
    private PointerController screen;

    public override void OnAwake()
    {
        base.OnAwake();
        UnbindButtons();
        BindButtons();
    }

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
        screenUpListeners?.Invoke();
    }

    private void OnScreenDown()
    {
        screenDownListeners?.Invoke();
    }
}