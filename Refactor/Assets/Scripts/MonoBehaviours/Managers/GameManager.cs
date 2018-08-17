using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
	public event Action<EmotionData> emotionChangedListeners;

	private Emotion currentEmotion;

	public override void OnAwake()
	{
		ControllerUI.instance.screenUpListeners += OnScreenPressed;
	}

    private void OnScreenPressed()
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

		var emotionData = EmotionsRegistry.instance.GetEmotionData(currentEmotion);

		emotionChangedListeners?.Invoke(emotionData);
	}
}