using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadWordFilePath : ILoadWordFilePath
{
    public WordFilePaths LoadFileContent(string filePath)
    {
        if (filePath == null)
        {
            Debug.LogError("Không tồn tại file");
            return null;
        }
        string jsonString = File.ReadAllText(filePath);
        return JsonUtility.FromJson<WordFilePaths>(jsonString);
    }
}
