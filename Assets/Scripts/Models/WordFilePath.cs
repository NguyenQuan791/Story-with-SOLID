using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordFilePath
{
    public string file_path;
    public int word_id;
}

[System.Serializable]
public class WordFilePaths
{
    public WordFilePath[] words;
}

