using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
	[Range(0.01f, 1f)]
	public float speed = 0.2f;
	public event Action<EmotionData> EmotionChangedListeners;

	private Emotion currentEmotion;

	public override void OnAwake()
	{
		ControllerUI.Instance.ScreenUpListeners += OnScreenPressed;

		//InvokeRepeating("OnScreenPressed", 0f, speed);
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