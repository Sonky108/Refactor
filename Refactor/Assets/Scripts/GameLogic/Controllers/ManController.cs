using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ManController: IManController, IInitializable, IDisposable
{
    private readonly SpriteRenderer mouth;

    private readonly CompositeDisposable disposables = new CompositeDisposable();
    
    private readonly SignalBus signalBus;

    [Inject]
    private readonly IAudioController audioController;

    private Emotion currentEmotion;

    public ManController(SpriteRenderer mouth, SignalBus signalBus)
    {
        this.mouth = mouth;
        this.signalBus = signalBus;
    }

    public void ChangeEmotion(EmotionChangedSignal emotionChangedSignal)
    {
        mouth.sprite = emotionChangedSignal.emotionData.mouth;
        audioController.Play(emotionChangedSignal.emotionData.onChangeSound);
    }

    public void Initialize()
    {
        signalBus.GetStream<EmotionChangedSignal>()
            .Subscribe(x => ChangeEmotion(x)).AddTo(disposables);
    }

    public void Dispose()
    {
        disposables.Dispose();
    }
}
