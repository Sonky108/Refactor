using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmotionData", menuName = "Man/EmotionData", order = 1)]
public class EmotionData : ScriptableObject 
{
	[SerializeField]
	private Emotion emotion;
	[SerializeField]
	private Texture mouth;
	[SerializeField]
	private AudioClip onChange;

    public Emotion Emotion
    {
        get
        {
            return emotion;
        }
    }

    public Texture Mouth
    {
        get
        {
            return mouth;
        }
    }

    public AudioClip OnChange
    {
        get
        {
            return onChange;
        }
    }
}
