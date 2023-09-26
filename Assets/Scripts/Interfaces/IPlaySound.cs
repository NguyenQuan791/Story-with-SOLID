using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaySound
{
    //Phát âm thanh truyền vào có thể lặp lại
    public void PlaySoundContent(AudioClip audioClip, AudioSource audioSource = null, bool loop = false);
}
