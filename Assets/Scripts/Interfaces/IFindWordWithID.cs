using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFindWordWithID 
{
    //Tìm dữ liệu word json từ trường word_id
    public Word FindWithID(WordFilePaths wordFilePaths, int wordID);
}
