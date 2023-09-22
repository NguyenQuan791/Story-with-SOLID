using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpamTextContentGameObject
{
    public void SpamTextContentGameObjects(GameObject gameObject, Transform parent = null, string text = "", float timeToDestroy = -1);
}
