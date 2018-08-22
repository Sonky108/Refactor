﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public PointerEvent onPointerDown;
    public PointerEvent onPointerUp;
    public PointerEvent onPointerPressed;
    
    private bool isPressed;
    private bool isUp;

    private void Awake()
    {
        onPointerDown = new PointerEvent();
        onPointerUp = new PointerEvent();
    }

    private void FixedUpdate()
    {
        if (isPressed)
            onPointerDown.DoInvoke();
        if (isUp)
            onPointerUp.DoInvoke(ResetUp);
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
}