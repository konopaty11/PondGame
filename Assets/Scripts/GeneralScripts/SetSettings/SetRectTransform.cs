using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRectTransform : MonoBehaviour
{
    /// <summary>
    /// Устанавливает настройки RectTransform
    /// </summary>
    /// <param name="transform"> объект компонента RectTransform </param>
    /// <param name="size"> размер </param>
    /// <param name="anchorMin"> минимальный якорь </param>
    /// <param name="anchorMax"> максимальный якорь </param>
    /// <param name="pivot"> пивота </param>
    /// <param name="anchoredPosition"> положение относительно якорей </param>
    public static void SetTransformSettings(RectTransform transform, Vector2 size,
        Vector2? anchorMin = null, Vector2? anchorMax = null, Vector2? pivot = null, Vector2? anchoredPosition = null)
    {
        if (anchorMin == null) transform.anchorMin = new Vector2(0.5f, 0.5f);
        else transform.anchorMin = anchorMin.Value;

        if (anchorMax == null) transform.anchorMax = new Vector2(0.5f, 0.5f);
        else transform.anchorMax = anchorMax.Value;

        if (pivot == null) transform.pivot = new Vector2(0.5f, 0.5f);
        else transform.pivot = pivot.Value;

        if (anchoredPosition == null) transform.anchoredPosition3D = Vector2.zero;
        else transform.anchoredPosition3D = anchoredPosition.Value;

        transform.sizeDelta = size;
    }
}
