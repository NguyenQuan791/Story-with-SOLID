using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : IAddCollider
{
    public void AddColliders(GameObject gameObject, List<Vector2> vector2s)
    {
        if (!gameObject.GetComponent<PolygonCollider2D>())
        {
            gameObject.AddComponent<PolygonCollider2D>();
        }
        PolygonCollider2D polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        polygonCollider2D.points = vector2s.ToArray();
    }
}
