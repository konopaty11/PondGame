using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateWinChangeDay : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Sprite spriteWindowChangeDay;  // ������ ���� ����� ���

    public static GameObject WinChangeDay { get; set; }     // ������ ���� ����� ���

    /// <summary>
    /// ������ ���� ����� ���
    /// </summary>
    public void CreateWindow()
    {
        WinChangeDay = new GameObject("WindowChangeDay");
        WinChangeDay.transform.SetParent(canvas.transform);

        Image winImage = WinChangeDay.AddComponent<Image>();
        winImage.sprite = spriteWindowChangeDay;

        RectTransform winTransform = WinChangeDay.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(winTransform, new Vector2(1800, 1045));
    }

}
