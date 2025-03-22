using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButtonMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// ���� ������ ������ �������� ������� � ������ ���� ������
    /// </summary>
    /// <param name="eventData"> ������ � ������ </param>
    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransform buttonTransform = GetComponent<RectTransform>();
        Text buttonText = GetComponentInChildren<Text>();

        buttonTransform.sizeDelta = new Vector2(470, 160);
        buttonText.color = new Color(0.06f, 0.5f, 0.04f, 1);
    }

    /// <summary>
    /// ���� �������� ������ ���������� ������� ������� � ���� ������
    /// </summary>
    /// <param name="eventData"> ������ � ������ </param>
   public void OnPointerUp(PointerEventData eventData)
    {
        RectTransform buttonTransform = GetComponent<RectTransform>();
        Text buttonText = GetComponentInChildren<Text>();

        buttonTransform.sizeDelta = new Vector2(493, 172);
        buttonText.color = Color.white;
    }
}
