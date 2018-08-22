using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerController : ObservableTriggerBase, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private Subject<Unit> onPointerUp;

    private bool isPressed;
    private bool isUp;

    private void FixedUpdate()
    {
        if (isPressed)
        {

        }
        if (isUp)
        {
            OnPointerUp();
        }
    }

    void OnPointerUp()
    {
        onPointerUp?.OnNext(Unit.Default);
        ResetUp();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        isUp = true;
    }

    //I do not want to invoke multiple times OnPointerUp event;
    private void ResetUp()
    {
        isUp = false;
    }

    public IObservable<Unit> PointerUp()
    {
        return onPointerUp ?? (onPointerUp = new Subject<Unit>());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPressed)
            isUp = true;
        isPressed = false;
 
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        isUp = false;
    }

    protected override void RaiseOnCompletedOnDestroy()
    {
        onPointerUp?.OnCompleted();
    }
}