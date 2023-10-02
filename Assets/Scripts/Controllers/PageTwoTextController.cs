using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PageTwoTextController : PageController
{
    #region Parameters and variables
    public AudioClip audioClip2;

    Word word;
    Word word2;
    Page page;
    WordFilePaths wordFilePaths;
    bool play = true;
    float times = -0.5f;

    GameObject[] autoTextGameObject;
    GameObject[] blinkGameObject;
    Transform textContent;
    Transform textContent2;
    #endregion

    #region Functions can override
    protected override void RunAwake()
    {
        this.page = loadPage.LoadFileContent(this.pageFilePath);
        this.wordFilePaths = loadWordFilePath.LoadFileContent(this.wordFilePath);

        this.word = loadText.FindWithID(this.wordFilePaths, this.page.text.First().word_id);
        this.word2 = loadText.FindWithID(this.wordFilePaths, this.page.text.Last().word_id);

        this.textContent = GameObject.FindGameObjectsWithTag(TagName.TEXT_CONTENT).OrderBy(m => m.name).First().transform;
        this.textContent2 = GameObject.FindGameObjectsWithTag(TagName.TEXT_CONTENT).OrderBy(m => m.name).Last().transform;

        this.blinkGameObject = GameObject.FindGameObjectsWithTag(TagName.BLINK).OrderBy(m => m.name).ToArray();
        this.spamGameObjectCollider.SpamGameObjectColliders(this.page, this.wordFilePaths, blinkGameObject, this.transform);
        this.hideAllBlink.HideAllBlinks(this.blinkGameObject);
    }

    protected override void RunStart()
    {
        string[] texts = this.word.text.Split(" ");

        foreach (var text in texts)
        {
            this.spamGameObjects.SpamTextContentGameObjects(this.autoText, this.textContent, text);
        }

        string[] text2s = this.word2.text.Split(" ");

        foreach (var text in text2s)
        {
            this.spamGameObjects.SpamTextContentGameObjects(this.autoText, this.textContent2, text);
        }
        this.textContent2.gameObject.SetActive(false);
        this.autoTextGameObject = GameObject.FindGameObjectsWithTag(TagName.AUTO_TEXT);
    }

    protected override void RunFixedUpdate()
    {
        this.times += Time.fixedDeltaTime;

        if (!reading && !textContent2.gameObject.activeSelf)
        {
            reading = true;
            this.times = 0f;
            audioClip = audioClip2;
            play = true;
            this.textContent.gameObject.SetActive(false);
            this.textContent2.gameObject.SetActive(true);
            this.autoTextGameObject = GameObject.FindGameObjectsWithTag(TagName.AUTO_TEXT);
            word = word2;
        }
        this.syncText.SyncTexts(this.autoTextGameObject, this.word, this.times, Color.red);


        if (times > 0 && this.play)
        {
            this.playSound.PlaySoundContent(audioClip, audioSource, false);
            this.play = false;
        }
    }
    #endregion
}