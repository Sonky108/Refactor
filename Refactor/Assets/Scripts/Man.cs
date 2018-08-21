using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man 
{
    private readonly SpriteRenderer mouth;
    private readonly IAudioController _IAudioController;
    private readonly IManInputController _IManInputController;

    private Emotion currentEmotion;

    public Man(SpriteRenderer mouth, IAudioController IAudioController)
    {
        this.mouth = mouth;
        this._IAudioController = IAudioController;
    }

    public void ChangeEmotion(EmotionData obj)
    {
        mouth.sprite = obj.mouth;
        //AudioController.instance.Play(obj.onChangeSound);
        _IAudioController.Play(obj.onChangeSound);
    }
}
