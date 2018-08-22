﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmotionsRegistry: IEmotionsRegistry
{
	[SerializeField]
	private List<EmotionData> emotions;

	public EmotionsRegistry(List<EmotionData> emotions)
	{
		this.emotions = emotions;
	}

	public EmotionData GetEmotionData(Emotion emotion)
	{
		var result = emotions.FirstOrDefault(x => x.emotion == emotion);

		if(result == null)
		{
			throw new KeyNotFoundException("Emotion data does not exist for following emotion: " + emotion.ToString());
		}

		return result;
	}

	[Serializable]
	public class Settings
	{
		public List<EmotionData> emotions;
	}
}
