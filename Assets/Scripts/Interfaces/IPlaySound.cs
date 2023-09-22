using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaySound
{
    public void PlaySoundContent(AudioClip audioClip, AudioSource audioSource = null, bool loop = false);
}
