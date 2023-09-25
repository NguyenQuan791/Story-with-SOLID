using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISyncText
{
    public void SyncTexts(GameObject[] texts, Word word, float time, Color color = default(Color));
}
