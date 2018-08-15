using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmotionData", menuName = "Man/EmotionData", order = 1)]
public class EmotionData : ScriptableObject {

	public Emotion Emotion;
	public Texture Mouth;
	public AudioClip OnChange;
}
