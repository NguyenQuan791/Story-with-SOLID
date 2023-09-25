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
    ISyncText syncText = new SyncText();
    ILoadWordFilePath loadWordFilePath = new LoadWordFilePath();
    IPlaySound playSound = new PlaySound();
    ISpamGameObjectCollider spamGameObjectCollider = new SpamGameObjectCollider();
    ISpamTextContentGameObject spamGameObjects = new SpamTextContentGameObject();

    Word word;
    Page page;
    WordFilePaths wordFilePaths;
    bool play = true;
    float times = -1;

    GameObject[] autoTextGameObject;

    private void Awake()
    {
        page = loadPage.LoadFileContent(pageFilePath);
        wordFilePaths = loadWordFilePath.LoadFileContent(wordFilePath);
        foreach (var item in wordFilePaths.words)
        {
            if(item.word_id == page.text[0].word_id)
            {
                word = loadText.LoadFileContent(item.file_path);
            }
        }
        spamGameObjectCollider.SpamGameObjectCollider(page, this.transform);
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

    private void FixedUpdate()
    {
        times += Time.fixedDeltaTime;
        syncText.SyncTexts(autoTextGameObject, word, times, Color.red);

        if (times > 0 && play)
        {
            playSound.PlaySoundContent(audioClip, audioSource, false);
        }
    }
}
