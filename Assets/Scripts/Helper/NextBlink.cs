using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlink : INextBlink
{
    public void NextBlinks(GameObject[] blinkGameObject)
    {
        IFindBlinked findBlinked = new FindBlinked();
        IHideAllBlink hideAllBlink = new HideAllBlink();

        hideAllBlink.HideAllBlinks(blinkGameObject);
        foreach (var item in blinkGameObject)
        {
            if (!findBlinked.FindBlinkeds(item, PageController.blinkeds))
            {
                item.gameObject.SetActive(true);
                break;
            }
        }
    }
}
