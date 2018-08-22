using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEmotionsRegistry 
{
    EmotionData GetEmotionData(Emotion emotion);
}
