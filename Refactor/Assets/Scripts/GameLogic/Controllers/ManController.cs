using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManController: IManController
{
    private readonly SpriteRenderer mouth;
    
    [Inject]
    private readonly IAudioController audioController;

    private Emotion currentEmotion;

    public ManController(SpriteRenderer mouth)
    {
        this.mouth = mouth;
    }

    public void ChangeEmotion(EmotionChangedSignal emotionChangedSignal)
    {
        mouth.sprite = emotionChangedSignal.emotionData.mouth;
        audioController.Play(emotionChangedSignal.emotionData.onChangeSound);
    }
}
