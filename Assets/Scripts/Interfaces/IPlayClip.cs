using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayClip
{
    //Phát âm thanh truyền vào một lần
    public void PlaySoundContent(AudioClip audioClip, AudioSource audioSource = null);
}
