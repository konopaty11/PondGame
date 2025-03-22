using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UninteractableUI: MonoBehaviour
{
    [SerializeField] Canvas canvas;

    /// <summary>
    /// скрывает UI объекты
    /// </summary>
    public void Uninteractable()
    {
        // отключение реакции UI на действия пользователя
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        eventSystem.enabled = false;

        // Вызов корутины
        StartCoroutine(DecreaseTransparency());
    }

    /// <summary>
    /// Постепенно уменьшает прозрачность всех дочерних UI канваса,
    /// за исключением самого канваса
    /// </summary>
    IEnumerator DecreaseTransparency()
    {
        // компоненты Image и Text канваса
        Image[] canvasImage = canvas.GetComponentsInChildren<Image>();
        Text[] canvasText = canvas.GetComponentsInChildren<Text>();

        // плавное уменьшение прозрачности
        for (float i = 1; i >= 0;i -= 0.02f)
        {
            // уменьшение прозрачности для Image
            foreach(Image image in canvasImage)
            {
                // не изменять прозрачность Image канваса
                if (image != null && image != canvas.GetComponent<Image>()) 
                {
                    Color color = image.color;
                    color.a = i;
                    image.color = color;
                }
            }

            // уменьшение прозрачности для Text
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
    /// возвращает UI объекты
    /// </summary>
    public void Interactable()
    {
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        eventSystem.enabled = true;
        StartCoroutine(IncreaseTransparency());
    }

    /// <summary>
    /// возвращает прозрачность объектов
    /// </summary>
    IEnumerator IncreaseTransparency()
    {
        // компоненты Image и Text канваса
        Image[] canvasImage = canvas.GetComponentsInChildren<Image>();
        Text[] canvasText = canvas.GetComponentsInChildren<Text>();

        // плавное увеличение прозрачности
        for (float i = 0; i <= 1; i += 0.02f)
        {
            // уменьшение прозрачности для Image
            foreach (Image image in canvasImage)
            {
                // не изменять прозрачность Image канваса
                if (image != null && image != canvas.GetComponent<Image>())
                {
                    Color color = image.color;
                    color.a = i;
                    image.color = color;
                }
            }

            // увеличение прозрачности для Text
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
