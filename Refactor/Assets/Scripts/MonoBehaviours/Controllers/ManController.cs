using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour, IManController
{
    [SerializeField]
    private SpriteRenderer mouth;

    private IAudioController audioController;

    public ManController(IAudioController audioController)
    {
        this.audioController = audioController;
    }
   /* public override void OnAwake()
    {
        GameManager.instance.emotionChangedListeners += OnEmotionChanged;
    }*/

    public void OnEmotionChanged(EmotionData obj)
    {
        mouth.sprite = obj.mouth;
        audioController.Play(obj.onChangeSound);
    }
}
