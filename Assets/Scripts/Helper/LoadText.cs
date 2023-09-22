using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadText : ILoadWord
{
    public Word LoadFileContent(string filePath)
    {
        string jsonString=File.ReadAllText(filePath);
        return JsonUtility.FromJson<Word>(jsonString);
    }
}
