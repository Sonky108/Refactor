using UnityEngine;

public static class AudioSourceExtensions 
{
    public static void Play(this AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    
    public static void Initialize(this AudioSource audioSource)
    {
        audioSource.playOnAwake = false;
        audioSource.clip = null;
        audioSource.loop = false;
    }
}
