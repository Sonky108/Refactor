using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionsRegistry : MonoBehaviourSingleton<EmotionsRegistry> 
{
	[SerializeField]
	private List<EmotionData> emotions;
}
