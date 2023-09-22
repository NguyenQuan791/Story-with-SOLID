using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRectTranform : IResetRectTranform
{
    public void ResetRectTranforms(RectTransform rectTransform)
    {
        rectTransform.localPosition = Vector3.zero;
        rectTransform.localScale = Vector3.one;
        rectTransform.anchorMax = Vector3.zero;
        rectTransform.anchorMin = Vector3.zero;
    }
}
