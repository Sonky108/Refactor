﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EmotionChangedSignal
{
	public EmotionData emotionData {get; private set;}

    public EmotionChangedSignal(EmotionData emotionData)
    {
		this.emotionData = emotionData;
    }
}

public class GameManager
{
	public event Action<EmotionData> emotionChangedListeners;

	private readonly SignalBus signalBus;

	private readonly IEmotionsRegistry emotionsRegistry;

	private Emotion currentEmotion;

    public GameManager(IEmotionsRegistry emotionsRegistry, SignalBus signalBus)
    {
		this.signalBus = signalBus;
		this.emotionsRegistry = emotionsRegistry;
    }

    /*public override void OnAwake()
	{
		ControllerUI.instance.screenUpListeners += OnScreenPressed;
	}*/

    public void OnScreenPressed()
    {
        if(EmotionCanBeChanged())
		{
			ChangeEmotion();
		}
    }

    private bool EmotionCanBeChanged()
    {
        return true;
    }

    private void ChangeEmotion()
	{
		currentEmotion = currentEmotion.Next();

		var emotionData = emotionsRegistry.GetEmotionData(currentEmotion);

		signalBus.Fire(new EmotionChangedSignal(emotionData));
		
		//emotionChangedListeners?.Invoke(emotionData);
	}
}