using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpamTextContentGameObject : MonoBehaviour, ISpamTextContentGameObject
{
    public void SpamTextContentGameObjects(GameObject gameObject, Transform parent = null, string text = "", float timeToDestroy = -1)
    {
        GameObject spamObject;
        if (text != "")
        {
            Text textGameObject;
            if (!gameObject.GetComponent<Text>())
            {
                textGameObject = gameObject.AddComponent<Text>();
            }
            else
            {
                textGameObject = gameObject.GetComponent<Text>();
            }
            textGameObject.text = text;
        }

        if(parent != null)
        {
            spamObject = Instantiate(gameObject, parent);
        }
        else
        {
            spamObject = Instantiate(gameObject);
        }

        if (timeToDestroy > 0)
        {
            Destroy(spamObject, timeToDestroy);
        }
    }
}
