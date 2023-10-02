using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightLightText : MonoBehaviour, IHightLightText
{
    GameObject hightLight = null;
    float time;
    bool hihht = true;
    public void HightLightTexts(string text)
    {
        if(hihht)
        {
            hihht = false;
            time = 0.5f;
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(TagName.AUTO_TEXT);

            foreach (GameObject gameObject in gameObjects)
            {
                Text gameObjectText= gameObject.GetComponent<Text>();
                if (gameObjectText.text.ToLower().Contains(text.ToLower()))
                {
                    hightLight = gameObject; 
                    break;
                }
            }

            if(hightLight != null)
            {
                Text gameObjectText = hightLight.GetComponent<Text>();
                gameObjectText.color= Color.red;

                InvokeRepeating(nameof(Run), 0.1f, 0.2f);
            }
        }
    }

    public void Run()
    {
        if (time < 0)
        {
            hightLight.transform.position = new Vector3(hightLight.transform.position.x, hightLight.transform.position.y - 0.15f);
            Text gameObjectText = hightLight.GetComponent<Text>();
            gameObjectText.color= Color.black;
            hihht = true;
            CancelInvoke(nameof(Run));
        }
        //Debug.Log(time % 0.2f);
        if (time % 0.2f < 0.1f)
        {
            hightLight.transform.position = new Vector3(hightLight.transform.position.x, hightLight.transform.position.y + 0.05f);
        }
        else
        {
            hightLight.transform.position = new Vector3(hightLight.transform.position.x, hightLight.transform.position.y - 0.05f);
        }
        time = time - 0.1f;
    }
}
