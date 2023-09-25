using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpamGameObjectCollider : ISpamGameObjectCollider
{
    void ISpamGameObjectCollider.SpamGameObjectCollider(Page pageStory, Transform parent = null)
    {
        IResetRectTranform resetRectTranform = new ResetRectTranform();
        IConvertStringToVecter convertStringToVecter = new ConvertStringToVecter();

        foreach (var image in pageStory.image)
        {
            List<Vector2> collider = new List<Vector2>();
            GameObject gameCollider = new GameObject();

            gameCollider.AddComponent<RectTransform>();

            if(parent != null)
            {
                gameCollider.transform.parent = parent;
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
            polygonCollider2D.points = collider.ToArray();
        }
    }
}
