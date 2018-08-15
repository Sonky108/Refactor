using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmotionData", menuName = "Man/EmotionData", order = 1)]
public class EmotionData : ScriptableObject 
{
	[SerializeField]
	private Emotion Emotion;
	[SerializeField]
	private Texture Mouth;
	[SerializeField]
	private AudioClip OnChange;
}
