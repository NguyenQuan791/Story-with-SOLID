using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    #region Parameters and variables
    public string pageFilePath;
    public string wordFilePath;

    public GameObject autoText;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public static GameObject[] blinkeds = {};
    public static bool reading = true;

    ILoadPage loadPage = new LoadPage();
    ISyncText syncText = new SyncText();
    IPlaySound playSound = new PlaySound();
    IShowBlink showBlink = new ShowBlink();
    IHideAllBlink hideAllBlink = new HideAllBlink();
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
    GameObject[] blinkGameObject;
    Transform textContent;
    #endregion

    private void Awake()
    {
        this.RunAwake();
    }

    private void Start()
    {
        this.RunStart();
    }

    private void FixedUpdate()
    {
        this.RunFixedUpdate();
    }

    #region Functions can override
   
    protected virtual void RunAwake()
    {
        this.page = loadPage.LoadFileContent(this.pageFilePath);
        this.wordFilePaths = loadWordFilePath.LoadFileContent(this.wordFilePath);
        this.word = loadText.FindWithID(this.wordFilePaths, this.page.text.First().word_id);
        this.textContent = GameObject.FindGameObjectWithTag(TagName.TEXT_CONTENT).transform;
        this.blinkGameObject = GameObject.FindGameObjectsWithTag(TagName.BLINK).OrderBy(m=>m.name).ToArray();
        this.spamGameObjectCollider.SpamGameObjectColliders(this.page, this.wordFilePaths, blinkGameObject, this.transform);
        this.hideAllBlink.HideAllBlinks(this.blinkGameObject);
    }

    protected virtual void RunStart()
    {
        string[] texts = this.word.text.Split(" ");

        foreach (var text in texts)
        {
            this.spamGameObjects.SpamTextContentGameObjects(this.autoText, this.textContent, text);
        }
        this.autoTextGameObject = GameObject.FindGameObjectsWithTag(TagName.AUTO_TEXT);
    }

    protected virtual void RunFixedUpdate()
    {
        this.times += Time.fixedDeltaTime;
        this.syncText.SyncTexts(this.autoTextGameObject, this.word, this.times, Color.red);
        this.showBlink.ShowBlinks(blinkGameObject, wordFilePaths, page);

        if (times > 0 && this.play)
        {
            this.playSound.PlaySoundContent(audioClip, audioSource, false);
            this.play = false;
        }
    }
    #endregion
}
