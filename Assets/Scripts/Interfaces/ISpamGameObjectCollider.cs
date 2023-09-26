using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpamGameObjectCollider
{
    //Tạo các game object có collider để bắt sự kiện click chuột
    public void SpamGameObjectColliders(Page pageStory, WordFilePaths wordFilePaths, GameObject[] blinkGameObject, Transform parent = null);
}
