using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
	public event Action<EmotionData> EmotionChangedListeners;

	private Emotion currentEmotion;

	public override void OnAwake()
	{
		ControllerUI.Instance.ScreenUpListeners += OnScreenPressed;
	}

    private void OnScreenPressed()
    {
        if(EmotionCanBeChanged())
		{
			ChangeEmotion();
			Debug.Log("Emotion changed");
		}
    }

    private bool EmotionCanBeChanged()
    {
        return true;
    }

    private void ChangeEmotion()
	{
		currentEmotion = currentEmotion.Next();

		var emotionData = EmotionsRegistry.Instance.GetEmotionData(currentEmotion);

		EmotionChangedListeners?.Invoke(emotionData);
	}

	private void Update()
	{
		/*if (Input.GetMouseButtonDown(0))
		{
			currentSprite++;

			if (currentSprite >= 4)
				currentSprite = 0;

			_image.GetComponent<Image>().sprite = sprites[currentSprite];

			if (_image.GetComponent<Image>().sprite.name == "mouth_lol")
			{
				GetComponent<AudioSource>().Play();
			}

		}*/
	}
}