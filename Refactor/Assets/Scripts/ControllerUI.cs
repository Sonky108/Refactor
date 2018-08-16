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
        Screen.OnPointerDown.AddListener(OnScreenDown);

        Screen.OnPointerUp.AddListener(OnScreenUp);
    }

    private void UnbindButtons()
    {
        Screen.OnPointerDown.RemoveListeners();

        Screen.OnPointerUp.RemoveListeners();
    }

    private void OnScreenUp()
    {
        ScreenUpListeners?.Invoke();
    }

    private void OnScreenDown()
    {
        ScreenDownListeners?.Invoke();
    }
}