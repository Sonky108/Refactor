using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviourSingleton<ManController> 
{
    [SerializeField]
    private SpriteRenderer Mouth;

    public override void OnAwake()
    {
        GameManager.Instance.EmotionChangedListeners += OnEmotionChanged;
    }

    private void OnEmotionChanged(EmotionData obj)
    {
        Mouth.sprite = obj.Mouth;
        AudioController.Instance.Play(obj.OnChange);
    }
}
