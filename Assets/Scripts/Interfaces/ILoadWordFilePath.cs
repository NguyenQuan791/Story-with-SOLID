using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadWordFilePath
{
    //Đọc file json chứa filepath của từng text
    public WordFilePaths LoadFileContent(string filePath);
}
