using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSpamText : MonoBehaviour
{
    #region Parameters and variables
    public GameObject spamText;
    public AudioClip audioClip;
    public string text;
    public float time = 1.5f;
    public GameObject blink;
    public GameObject[] blinkGameObject;

    static GameObject spamToDestroy;

    IAddBlinked addBlinked=new AddBlinked();
    INextBlink nextBlink=new NextBlink();
    #endregion

    private void OnMouseDown()
    {
        if (PageController.reading)
        {
            return;
        }
        IPlayClip playClip = new PlayClip();
        playClip.PlaySoundContent(this.audioClip);
        Text textComponent = spamText.GetComponentInChildren<Text>();
        textComponent.text = this.text;
        Quaternion quaternion = Quaternion.Euler(0, 0, Random.Range(-15f, 15f));
        Vector2 vector2 = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (spamToDestroy)
        {
            Destroy(spamToDestroy);
        }
        addBlinked.AddBlinkeds(blink);
        nextBlink.NextBlinks(blinkGameObject);
        spamToDestroy = Instantiate(spamText, vector2, quaternion, this.transform);
        Destroy(spamToDestroy, time);
    }
}
