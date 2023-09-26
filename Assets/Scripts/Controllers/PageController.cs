using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class PageController : MonoBehaviour
{
    #region Parameters and variables
    public string pageFilePath;
    public string wordFilePath;

    public GameObject autoText;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public static GameObject[] blinkeds = { };
    public static bool reading = true;

    protected ILoadPage loadPage = new LoadPage();
    protected ISyncText syncText = new SyncText();
    protected IPlaySound playSound = new PlaySound();
    protected IShowBlink showBlink = new ShowBlink();
    protected IHideAllBlink hideAllBlink = new HideAllBlink();
    protected IFindWordWithID loadText = new FindWordWithID();
    protected ILoadWordFilePath loadWordFilePath = new LoadWordFilePath();
    protected ISpamTextContentGameObject spamGameObjects = new SpamTextContentGameObject();
    protected ISpamGameObjectCollider spamGameObjectCollider = new SpamGameObjectCollider();

    //Word word;
    //Page page;
    //WordFilePaths wordFilePaths;
    //bool play = true;
    //float times = -0.2f;

    //GameObject[] autoTextGameObject;
    //GameObject[] blinkGameObject;
    //Transform textContent;
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
        Debug.Log("Đang Awake");
    }

    protected virtual void RunStart()
    {
        Debug.Log("Đang Start");
    }

    protected virtual void RunFixedUpdate()
    {
        Debug.Log("Đang FixUpdate");
    }
    #endregion
}
