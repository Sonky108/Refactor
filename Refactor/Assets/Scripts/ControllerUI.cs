using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviourSingleton<ControllerUI>
{
    public event Action ScreenDownListeners;
    public event Action ScreenUpListeners;

    [Header("Buttons")]

    [SerializeField]
    private PointerController Screen;

    public override void OnAwake()
    {
        base.OnAwake();
        UnbindButtons();
        BindButtons();
    }

    private void BindButtons()
    {
        Screen.OnPointerDown.AddListener(OnTurnLeftButtonPressed);

        Screen.OnPointerUp.AddListener(OnTurnLeftButtonReleased);
    }

    private void UnbindButtons()
    {
        Screen.OnPointerDown.RemoveListeners();

        Screen.OnPointerUp.RemoveListeners();
    }

    private void OnTurnLeftButtonReleased()
    {
        ScreenUpListeners?.Invoke();
    }

    private void OnTurnLeftButtonPressed()
    {
        ScreenDownListeners?.Invoke();
    }
}