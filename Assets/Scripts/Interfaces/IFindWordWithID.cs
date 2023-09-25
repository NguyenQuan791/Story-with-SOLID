using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFindWordWithID 
{
    public Word FindWithID(WordFilePaths wordFilePaths, int wordID);
}
