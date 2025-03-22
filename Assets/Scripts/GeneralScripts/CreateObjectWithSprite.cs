using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObjectWithSprite : MonoBehaviour
{
    /// <summary>
    /// ������ ������, ��������� ��� �� ��������,
    /// ��������� ��������� Image � ������������� ������
    /// </summary>
    /// <param name="name"> ��� ������� </param>
    /// <param name="parent"> ������ �������� </param>
    /// <param name="sprite"> ������ ������� </param>
    /// <returns> ��������� ������ </returns>
    public static GameObject CreateSprite(string name, Sprite sprite, GameObject parent = null)
    {
        GameObject body = new GameObject(name);
        if (parent != null) body.transform.SetParent(parent.transform);

        Image bodyImage = body.AddComponent<Image>();
        bodyImage.sprite = sprite;

        return body;
    }
}
