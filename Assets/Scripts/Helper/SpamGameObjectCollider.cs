using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpamGameObjectCollider : ISpamGameObjectCollider
{
    public void SpamGameObjectColliders(Page pageStory, WordFilePaths wordFilePaths, GameObject[] blinkGameObject, Transform parent = null)
    {
        IResetRectTranform resetRectTranform = new ResetRectTranform();
        IConvertStringToVecter convertStringToVecter = new ConvertStringToVecter();
        IFindWordWithID findWordWithID = new FindWordWithID();
        foreach (var image in pageStory.image)
        {
            if (image.touch.First().vertices.Length == 0)
            {
                continue;
            }
            List<Vector2> collider = new List<Vector2>();
            GameObject gameCollider = new GameObject();
            gameCollider.AddComponent<RectTransform>();
            gameCollider.AddComponent<ClickSpamText>();
            gameCollider.AddComponent<HightLightText>();
            Word word = findWordWithID.FindWithID(wordFilePaths, image.word_id);

            if (parent != null)
            {
                gameCollider.transform.SetParent(parent);
            }
            RectTransform rectTransform = gameCollider.GetComponent<RectTransform>();
            resetRectTranform.ResetRectTranforms(rectTransform);

            foreach (var touch in image.touch)
            {
                foreach (var vertice in touch.vertices)
                {
                    collider.Add(convertStringToVecter.ConvertStringToVecter2(vertice));
                }
            }
            gameCollider.AddComponent<PolygonCollider2D>();
            PolygonCollider2D polygonCollider2D = gameCollider.GetComponent<PolygonCollider2D>();
            ClickSpamText clickSpamText = gameCollider.GetComponent<ClickSpamText>();

            polygonCollider2D.points = collider.ToArray();
            clickSpamText.audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audios/"+word.text+".mp3");
            clickSpamText.text = word.text;
            clickSpamText.spamText = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Spam Text.prefab");
            clickSpamText.blinkGameObject = blinkGameObject;

            foreach (var item in blinkGameObject)
            {
                if (item.name.Split('_').Last().ToLower() == word.text)
                {
                    clickSpamText.blink = item;
                    break;
                }
            }
        }
    }
}
