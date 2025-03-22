using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AFW = AddFishWindow;

public class AddFishText : MonoBehaviour
{
    [SerializeField] Font fontHeader;           // шрифт заголовка
    [SerializeField] public Font font;                 // обычный шрифт

    /// <summary>
    /// Создаёт весь текст в окне добавления рыб
    /// </summary>
    public void CreateTextWindow()
    {
        // заголовок
        GameObject header = new GameObject("Header");
        header.transform.SetParent(AFW.window.transform);

        Text headerText = header.AddComponent<Text>();
        string str = "Добавте рыбу в пруд";
        SetText.SetTextSettings(headerText, str, fontHeader, 60, new Color(0, 0.5245282f, 0.008282918f, 1), TextAnchor.MiddleCenter, FontStyle.Bold);

        RectTransform headerTransform = header.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(headerTransform, new Vector2(1000, 200), new Vector2(0.23f, 0.92f), new Vector2(0.23f, 0.92f));


        // основной текст окунь
        GameObject textPerch = new GameObject("TextPerch");
        textPerch.transform.SetParent(AFW.window.transform);

        Text textAboutPerch = textPerch.AddComponent<Text>();
        SetText.SetTextSettings(textAboutPerch, "", font, 45, Color.black, TextAnchor.UpperLeft);

        str = "Речной окунь - всеядная рыба, изначально обитала в Европе и Северной Азии";
        StartCoroutine(PrintMsgInWindow.PrintMsg(textAboutPerch, str));

        RectTransform textPerchTransform = textPerch.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textPerchTransform, new Vector2(1000, 200), new Vector2(0.32f, 0.72f), new Vector2(0.32f, 0.72f));


        // основной текст щука
        GameObject textPike = new GameObject("TextPike");
        textPike.transform.SetParent(AFW.window.transform);

        Text textAboutPike = textPike.AddComponent<Text>();
        SetText.SetTextSettings(textAboutPike, "", font, 45, Color.black, TextAnchor.UpperLeft);

        str = "Щука обыкновенная - хищник весом до 35кг, обитает в Евразии и Северной Америке";
        StartCoroutine(PrintMsgInWindow.PrintMsg(textAboutPike, str));


        RectTransform textPikeTransform = textPike.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textPikeTransform, new Vector2(1000, 200), new Vector2(0.32f, 0.45f), new Vector2(0.32f, 0.45f));


        // основной текст карась
        GameObject textCrucian = new GameObject("TextCrucian");
        textCrucian.transform.SetParent(AFW.window.transform);

        Text textAboutCrucian = textCrucian.AddComponent<Text>();
        SetText.SetTextSettings(textAboutCrucian, "", font, 45, Color.black, TextAnchor.UpperLeft);

        str = "Карась - травоядная рыба, способна выдеражать промерзание водоёма до дна, обитает в болотистых озёрах и реках";
        StartCoroutine(PrintMsgInWindow.PrintMsg(textAboutCrucian, str));

        RectTransform textCrucianTransform = textCrucian.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textCrucianTransform, new Vector2(1000, 400), new Vector2(0.32f, 0.07f), new Vector2(0.32f, 0.07f));

    }
}
