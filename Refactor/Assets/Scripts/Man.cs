using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Man: IMan
{
    private readonly SpriteRenderer mouth;
    
    [Inject]
    private readonly IAudioController _IAudioController;

    private Emotion currentEmotion;

    public Man(SpriteRenderer mouth)
    {
        this.mouth = mouth;
    }

    public void ChangeEmotion(EmotionChangedSignal emotionChangedSignal)
    {
        mouth.sprite = emotionChangedSignal.emotionData.mouth;
        //AudioController.instance.Play(obj.onChangeSound);
        _IAudioController.Play(emotionChangedSignal.emotionData.onChangeSound);
    }
}
