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
    ISyncText syncText = new SyncText();
    IPlaySound playSound = new PlaySound();
    IFindWordWithID loadText = new FindWordWithID();
    ILoadWordFilePath loadWordFilePath = new LoadWordFilePath();
    ISpamTextContentGameObject spamGameObjects = new SpamTextContentGameObject();
    ISpamGameObjectCollider spamGameObjectCollider = new SpamGameObjectCollider();

    Word word;
    Page page;
    WordFilePaths wordFilePaths;
    bool play = true;
    float times = -0.2f;

    GameObject[] autoTextGameObject;

    private void Awake()
    {
        this.page = loadPage.LoadFileContent(this.pageFilePath);
        this.wordFilePaths = loadWordFilePath.LoadFileContent(this.wordFilePath);
        if (this.page.text.Length == 1)
        {
            this.word = loadText.FindWithID(this.wordFilePaths, this.page.text[0].word_id);
        }
        this.spamGameObjectCollider.SpamGameObjectColliders(this.page, this.wordFilePaths, this.transform);
    }

    private void Start()
    {
        string[] texts = this.word.text.Split(" ");

        foreach (var text in texts)
        {
           this.spamGameObjects.SpamTextContentGameObjects(this.autoText, this.textContent, text);
        }
        this.autoTextGameObject = GameObject.FindGameObjectsWithTag(TagName.AUTO_TEXT);
    }

    private void FixedUpdate()
    {
        this.times += Time.fixedDeltaTime;
        this.syncText.SyncTexts(this.autoTextGameObject, this.word, this.times, Color.red);

        if (times > 0 && this.play)
        {
            this.playSound.PlaySoundContent(audioClip, audioSource, false);
            this.play = false;
        }
    }
}
