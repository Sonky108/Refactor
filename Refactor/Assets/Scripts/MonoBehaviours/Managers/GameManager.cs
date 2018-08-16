using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
	public event Action<EmotionData> EmotionChangedListeners;

	private Emotion currentEmotion;

	private void GetNextEmotion()
	{
		currentEmotion = currentEmotion.Next();

		var emotionData = EmotionsRegistry.Instance.GetEmotionData(currentEmotion);

		EmotionChangedListeners?.Invoke(emotionData);
	}

	public override void OnAwake()
	{
		InvokeRepeating("GetNextEmotion", 0f, 0.4f);
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