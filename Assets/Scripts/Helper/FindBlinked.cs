using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBlinked : IFindBlinked
{
    public bool FindBlinkeds(GameObject blinked, GameObject[] blinkGameObject)
    {
        foreach (GameObject gameObject in PageController.blinkeds)
        {
            if (gameObject == blinked)
            {
                return true;
            }
        }
        return false;
    }
}
