using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindWordWithID : IFindWordWithID
{
    public Word FindWithID(WordFilePaths wordFilePaths, int wordID)
    {
        ILoadWord loadWord = new LoadText();
        Word word = null;

        foreach (var item in wordFilePaths.words)
        {
            if (item.word_id == wordID)
            {
                word = loadWord.LoadFileContent(item.file_path);
                break;
            }
        }

        return word;
    }
}
