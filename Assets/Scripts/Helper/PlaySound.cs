using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : IPlaySound
{
    public void PlaySoundContent(AudioClip audioClip, AudioSource audioSource = null, bool loop = false)
    {
        if (audioSource == null)
        {
            audioSource = GameObject.FindObjectOfType<AudioSource>();
        }

        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.Play();
    }
}