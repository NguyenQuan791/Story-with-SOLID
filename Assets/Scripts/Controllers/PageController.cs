using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public string pageFilePath;
    public string wordFilePath;

    public GameObject autoText;
    public Transform textContent;
    public AudioSource audioSource;
    public AudioClip audioClip;

    ILoadPage loadPage = new LoadPage();
    ILoadWord loadText = new LoadText();
    IPlaySound playSound = new PlaySound();
    ISpamTextContentGameObject spamGameObjects = new SpamTextContentGameObject();
    IConvertStringToVecter convertStringToVecter = new ConvertStringToVecter();
    IAddCollider addCollider = new AddCollider();
    IResetRectTranform resetRectTranform = new ResetRectTranform();
    ISyncText syncText = new SyncText();

    Word word;
    Page page;
    float times = -1;
    bool play = true;

    GameObject[] autoTextGameObject;

    private void Awake()
    {
        word = loadText.LoadFileContent(wordFilePath);
        page = loadPage.LoadFileContent(pageFilePath);

        foreach (var image in page.image)
        {
            List<Vector2> collider = new List<Vector2>();
            GameObject gameCollider = new GameObject();

            gameCollider.AddComponent<RectTransform>();
            gameCollider.transform.parent = this.transform;
            RectTransform rectTransform = gameCollider.GetComponent<RectTransform>();
            resetRectTranform.ResetRectTranforms(rectTransform);

            foreach(var touch in image.touch)
            {
                foreach(var vertice in touch.vertices)
                {
                    collider.Add(convertStringToVecter.ConvertStringToVecter2(vertice));
                }
            }

            gameCollider.AddComponent<PolygonCollider2D>();
            addCollider.AddColliders(gameCollider, collider);
        }
    }

    private void Start()
    {
        string[] texts = word.text.Split(" ");

        foreach (var text in texts)
        {
           spamGameObjects.SpamTextContentGameObjects(autoText, textContent, text);
        }

        autoTextGameObject = GameObject.FindGameObjectsWithTag(TagName.AUTO_TEXT);
    }

    void PlaySound()
    {
        playSound.PlaySoundContent(audioClip, audioSource);
    }

    private void FixedUpdate()
    {
        if (this.word.audio[0].sync_data[this.word.audio[0].sync_data.Length - 1].e > times * 1000)
        {
            times += Time.fixedDeltaTime;

            foreach (var item in this.word.audio[0].sync_data)
            {
                if (item.s - times * 1000 <= 0 && times * 1000 - item.e <= 0)
                {
                    syncText.SyncTexts(autoTextGameObject, item.w, Color.red);
                    
                    if (play)
                    {
                        PlaySound();
                        play = false;
                    }
                    return;
                }
            }
            if (this.word.audio[0].sync_data[0].e < times * 1000 + 100)
            {
                syncText.SyncTexts(autoTextGameObject, "", Color.red);
            }
        }
    }
}
