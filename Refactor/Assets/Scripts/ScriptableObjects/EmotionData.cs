using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmotionData", menuName = "Man/EmotionData", order = 1)]
public class EmotionData : ScriptableObject 
{
	[SerializeField]
	private Emotion _emotion;
	[SerializeField]
	private Sprite _mouth;
	[SerializeField]
	private AudioClip _onChangeSound;

    public Emotion emotion
    {
        get
        {
            return _emotion;
        }
    }

    public Sprite mouth
    {
        get
        {
            return _mouth;
        }
    }

    public AudioClip onChangeSound
    {
        get
        {
            return _onChangeSound;
        }
    }
}
