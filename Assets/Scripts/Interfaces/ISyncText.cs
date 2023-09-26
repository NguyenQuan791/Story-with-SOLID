using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISyncText
{
    // Thay đổi màu chữ theo thời gian
    public void SyncTexts(GameObject[] texts, Word word, float time, Color color = default(Color));
}
