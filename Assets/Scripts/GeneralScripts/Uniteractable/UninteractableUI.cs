using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UninteractableUI: MonoBehaviour
{
    [SerializeField] Canvas canvas;

    /// <summary>
    /// �������� UI �������
    /// </summary>
    public void Uninteractable()
    {
        // ���������� ������� UI �� �������� ������������
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;

        // ����� ��������
        StartCoroutine(DecreaseTransparency());
    }

    /// <summary>
    /// ���������� ��������� ������������ ���� �������� UI �������,
    /// �� ����������� ������ �������
    /// </summary>
    IEnumerator DecreaseTransparency()
    {
        // ���������� Image � Text �������
        Image[] canvasImage = canvas.GetComponentsInChildren<Image>();
        Text[] canvasText = canvas.GetComponentsInChildren<Text>();

        // ������� ���������� ������������
        for (float i = 1; i >= 0;i -= 0.02f)
        {
            // ���������� ������������ ��� Image
            foreach(Image image in canvasImage)
            {
                // �� �������� ������������ Image �������
                if (image != null && image != canvas.GetComponent<Image>()) 
                {
                    Color color = image.color;
                    color.a = i;
                    image.color = color;
                }
            }

            // ���������� ������������ ��� Text
            foreach (Text text in canvasText)
            {
                if (text != null)
                {
                    Color color = text.color;
                    color.a = i;
                    text.color = color;
                }
            }

            yield return new WaitForSeconds(0.01f);
        }


    }

    /// <summary>
    /// ���������� UI �������
    /// </summary>
    public void Interactable()
    {
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        eventSystem.enabled = true;
        StartCoroutine(IncreaseTransparency());
    }

    /// <summary>
    /// ���������� ������������ ��������
    /// </summary>
    IEnumerator IncreaseTransparency()
    {
        // ���������� Image � Text �������
        Image[] canvasImage = canvas.GetComponentsInChildren<Image>();
        Text[] canvasText = canvas.GetComponentsInChildren<Text>();

        // ������� ���������� ������������
        for (float i = 0; i <= 1; i += 0.02f)
        {
            // ���������� ������������ ��� Image
            foreach (Image image in canvasImage)
            {
                // �� �������� ������������ Image �������
                if (image != null && image != canvas.GetComponent<Image>())
                {
                    Color color = image.color;
                    color.a = i;
                    image.color = color;
                }
            }

            // ���������� ������������ ��� Text
            foreach (Text text in canvasText)
            {
                if (text != null)
                {
                    Color color = text.color;
                    color.a = i;
                    text.color = color;
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

}
