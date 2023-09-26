using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFindBlinked
{
    //Tìm các game object blink trong chuỗi blink
    public bool FindBlinkeds(GameObject blinked, GameObject[] blinkGameObject);
}
