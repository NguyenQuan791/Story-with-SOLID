using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertStringToVecter : IConvertStringToVecter
{
    public Vector2 ConvertStringToVecter2(string strVecter)
    {
        string[] splitString = strVecter.Trim('{','}',' ').Split(',');
        return new Vector2(float.Parse(splitString[0]), float.Parse(splitString[1]));
    }
}
