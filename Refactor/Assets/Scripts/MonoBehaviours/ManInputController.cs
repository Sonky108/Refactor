using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ManInputController : MonoBehaviour, IManInputController, IPointerUpHandler, IPointerExitHandler, IPointerDownHandler
{
    private bool isPressed;
    private bool isUp;

    public void FixedUpdate()
    {
        Debug.Log("FIX");
        if (isPressed)
            OnPointerDown();
        if (isUp)
            OnPointerReleased();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

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
                Debug.Log("OnPointerExit");
        if (isPressed)
            isUp = true;
        isPressed = false;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        isPressed = true;
        isUp = false;
    }

    public void OnPointerReleased()
    {
        //SiGnal?
        Debug.Log("Releeased");
        ResetUp();
    }

    public void OnPointerDown()
    {

    }
}
