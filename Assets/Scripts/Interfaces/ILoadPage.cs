using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadPage
{
    //Load dữ liệu json của file path
    public Page LoadFileContent(string filePath);
}
