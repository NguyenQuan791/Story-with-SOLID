using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpamTextContentGameObject
{
    //Tạo các game object để chứa text
    public void SpamTextContentGameObjects(GameObject gameObject, Transform parent = null, string text = "");
}
