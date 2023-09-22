using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISyncText
{
    public void SyncTexts(GameObject[] texts, string text, Color color = default(Color));
}
