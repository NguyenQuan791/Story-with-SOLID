using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncText : ISyncText
{
    public void SyncTexts(GameObject[] texts, Word word, float time, Color syncColor = default)
    {
        if (word.audio[0].sync_data[word.audio[0].sync_data.Length - 1].e < time * 1000 - 200)
        {
            return;
        }

        foreach (var item in word.audio[0].sync_data)
        {
            if (item.s - time * 1000 <= 0 && time * 1000 - item.e <= 0)
            {
                foreach (var text in texts)
                {
                    Text itemText = text.GetComponent<Text>();

                    if (itemText.text.ToLower() == item.w.ToLower())
                    {
                        itemText.color = syncColor;
                    }
                    else
                    {
                        itemText.color = Color.black;
                    }
                }
                return;
            }
        }

        if (word.audio[0].sync_data[word.audio[0].sync_data.Length - 1].e < time * 1000)
        {
            foreach (var text in texts)
            {
                Text itemText = text.GetComponent<Text>();
                itemText.color = Color.black;
            }
            PageController.reading = false;
        }
    }
}
