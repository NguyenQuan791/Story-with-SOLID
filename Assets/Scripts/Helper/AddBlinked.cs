using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlinked : IAddBlinked
{
    public void AddBlinkeds(GameObject blinked)
    {
        IFindBlinked findBlinked = new FindBlinked();
        bool add = true;

        if (findBlinked.FindBlinkeds(blinked, PageController.blinkeds))
        {
            add = false;
        }

        if (add)
        {
            Array.Resize(ref PageController.blinkeds, PageController.blinkeds.Length+1);
            PageController.blinkeds[PageController.blinkeds.Length-1] = blinked;
        }
    }
}
