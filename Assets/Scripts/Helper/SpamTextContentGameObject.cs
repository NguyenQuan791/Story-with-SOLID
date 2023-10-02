using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpamTextContentGameObject : MonoBehaviour, ISpamTextContentGameObject
{
    public void SpamTextContentGameObjects(GameObject gameObject, Transform parent = null, string text = "")
    {
        if (text != "")
        {
            if (!gameObject.GetComponent<Text>())
            {
                gameObject.AddComponent<Text>();
            }
            Text textGameObject = gameObject.GetComponent<Text>();
            textGameObject.text = text;
        }

        if (parent != null)
        {
            Instantiate(gameObject, parent);
        }
        else
        {
            Instantiate(gameObject);
        }
    }
}
