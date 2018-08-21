using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioController 
{
    void Play(AudioClip clip, bool forcePlay = true);
}
