﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioController : MonoBehaviourSingleton<AudioController> 
{
    [SerializeField]
    private AudioSource mainAudioSource;

    private List<AudioSource> audioSources;

    public override void OnAwake()
    {
        Initialize();
    }

    public void Play(AudioClip clip, bool forcePlay = true)
    {
        if(clip == null) return;

        if(forcePlay)
        {
            var audioSource = GetAudioSource();

            audioSource.Play(clip);
        }
        else
        {
            mainAudioSource.Play(clip);
        }
    }

    private AudioSource GetAudioSource()
    {
        var audioSource = GetUnusedAudioSource();

        if(audioSource == null)
        {
            audioSource = CreateAudioSource();
        }

        return audioSource;
    }

    private AudioSource GetUnusedAudioSource()
    {
        var result = audioSources.FirstOrDefault(x => !x.isPlaying);

        return result;
    }

    private AudioSource CreateAudioSource()
    {
        var gameObject = new GameObject();

        gameObject.transform.parent = this.gameObject.transform;

        var audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.Initialize();

        AddAudioSourceToList(audioSource);

        return audioSource;
    }

    private void AddAudioSourceToList(AudioSource audioSource)
    {
        audioSources.Add(audioSource);
    }

    private void Initialize()
    {
        mainAudioSource.Initialize();

        audioSources = new List<AudioSource>();

        AddAudioSourceToList(mainAudioSource);
    }
}
