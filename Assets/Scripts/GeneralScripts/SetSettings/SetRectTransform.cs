using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRectTransform : MonoBehaviour
{
    /// <summary>
    /// ������������� ��������� RectTransform
    /// </summary>
    /// <param name="transform"> ������ ���������� RectTransform </param>
    /// <param name="size"> ������ </param>
    /// <param name="anchorMin"> ����������� ����� </param>
    /// <param name="anchorMax"> ������������ ����� </param>
    /// <param name="pivot"> ������ </param>
    /// <param name="anchoredPosition"> ��������� ������������ ������ </param>
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
