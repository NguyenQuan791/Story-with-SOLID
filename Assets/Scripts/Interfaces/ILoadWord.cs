using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadWord
{
    //Load dữ liệu json của file path
    public Word LoadFileContent(string filePath);
}
