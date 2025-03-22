using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateLoadingText : MonoBehaviour
{
    [SerializeField] Font font;
    [SerializeField] Canvas canvas;

    GameObject loadingTextObject;
    Text loadingText;

    public void CreateText()
    {
        loadingTextObject = new GameObject("LoadingText");          // Создание пустышки
        loadingTextObject.transform.SetParent(canvas.transform);    // Обеспечение наследования пустышки от канваса


        // добавление к пустышке компанент Text
        loadingText = loadingTextObject.AddComponent<Text>();

        // Форматирование текста
        loadingText.text = "Загрузка";
        loadingText.alignment = TextAnchor.MiddleCenter;
        loadingText.font = font;
        loadingText.fontSize = 150;


        // добавление компанента transform
        RectTransform loadingTextTransform = loadingText.GetComponent<RectTransform>();

        // установка якорей
        loadingTextTransform.offsetMax = new Vector2(0.5f, 0.5f);
        loadingTextTransform.offsetMin = new Vector2(0.5f, 0.5f);

        // Позиция относительно якорей
        loadingTextTransform.anchoredPosition = Vector2.zero;
        // размер текстового поля
        loadingTextTransform.sizeDelta = new Vector2(1000, 400);


        // Вызов корутин
        StartCoroutine(Apperance());
        StartCoroutine(Animation());
    }

    /// <summary>
    /// Плавно выводит текст загрузки на сцену
    /// </summary>
    /// <returns></returns>
    IEnumerator Apperance()
    {
        // Прозрачный текст
        loadingText.color = Color.clear;

        // постепенное появление
        for(float i = 0; i < 1; i += 0.02f)
        {
            loadingText.color = new Color(0, 0, 0, i);

            yield return new WaitForSeconds(0.02f);
        }
    }

    /// <summary>
    /// Анимирует текст загрузки
    /// </summary>
    /// <returns></returns>
    IEnumerator Animation()
    {
        string primaryText = loadingText.text;  // первичный текст
        // анимация загрузки
        for(int i = 8; i > 0; i--)
        {
            if (i % 4 == 0) loadingText.text = primaryText;
            else loadingText.text += ".";

            yield return new WaitForSeconds(0.33f);
        }

        // загрузка новой сцены
        LoadScene();
    }

    /// <summary>
    /// Загружает сцену Game
    /// </summary>
    void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
