using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClip : IPlayClip
{
    public void PlaySoundContent(AudioClip audioClip, AudioSource audioSource = null)
    {
        if(audioSource == null)
        {
            audioSource = GameObject.FindObjectOfType<AudioSource>();
        }
        audioSource.PlayOneShot(audioClip);
    }
}
