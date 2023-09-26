using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAllBlink : IHideAllBlink
{
    public void HideAllBlinks(GameObject[] blink)
    {
        foreach (GameObject obj in blink)
        {
            obj.SetActive(false);
        }
    }
}
