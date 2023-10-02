using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShowBlink : IShowBlink
{
    public void ShowBlinks(GameObject[] blinkGameObject, WordFilePaths wordFilePath, Page page)
    {
        IFindBlinked findBlinked = new FindBlinked();
        IFindWordWithID findWordWithID = new FindWordWithID();

        string text = findWordWithID.FindWithID(wordFilePath, page.image.Last().word_id).text;

        if (!PageController.reading)
        {
            foreach (var item in blinkGameObject)
            {
                if (!findBlinked.FindBlinkeds(item, PageController.blinkeds) && item.name.Split('_').Last().ToLower() == text)
                {
                    item.gameObject.SetActive(true);
                    break;
                } 
            }
        }
    }
}
