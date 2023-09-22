using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncText : ISyncText
{
    public void SyncTexts(GameObject[] texts, string text, Color syncColor = default)
    {
        foreach (var item in texts)
        {
            Text itemText = item.GetComponent<Text>();

            if (itemText.text.ToLower() == text.ToLower())
            {
                itemText.color = syncColor;
            }
            else
            {
                itemText.color = Color.black;
            }
        }
    }
}
