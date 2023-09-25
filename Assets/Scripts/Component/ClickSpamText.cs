using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSpamText : MonoBehaviour
{
    public GameObject spamText;
    public AudioClip audioClip;
    public string text;
    public float time = 1.5f;

    IPlayClip playClip = new PlayClip();
    static GameObject spamToDestroy;

    private void OnMouseDown()
    {
        this.playClip.PlaySoundContent(this.audioClip);
        Text textComponent = spamText.GetComponentInChildren<Text>();
        textComponent.text = this.text;
        Quaternion quaternion = Quaternion.Euler(0, 0, Random.Range(-15f, 15f));
        Vector2 vector2 = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (spamToDestroy)
        {
            Destroy(spamToDestroy);
        }
        spamToDestroy = Instantiate(spamText, vector2, quaternion, this.transform);
        Destroy(spamToDestroy, time);
    }
}
