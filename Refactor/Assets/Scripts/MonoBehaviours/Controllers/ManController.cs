using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviourSingleton<ManController>, IManController
{
    [SerializeField]
    private SpriteRenderer mouth;

    public override void OnAwake()
    {
        GameManager.instance.emotionChangedListeners += OnEmotionChanged;
    }

    public void OnEmotionChanged(EmotionData obj)
    {
        mouth.sprite = obj.mouth;
        AudioController.instance.Play(obj.onChangeSound);
    }
}
