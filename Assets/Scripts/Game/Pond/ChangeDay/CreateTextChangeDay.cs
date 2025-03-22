using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateTextChangeDay : MonoBehaviour
{
    // шрифты
    [SerializeField] Font fontHeader;
    [SerializeField] Font font;

    // префаб окна ввода
    [SerializeField] GameObject prefabInputField;

    // объекты поля ввода и текста ввода
    public static GameObject InputField { get; set; }
    public static InputField InputText { get; set; }

    GameObject error = null;    // объект текста ошибки

    /// <summary>
    /// создание текста окна смены дня
    /// </summary>
    public void CreateTextWinChangeDay()
    {
        // заголовок
        GameObject header = new GameObject("HeaderText");
        header.transform.SetParent(CreateWinChangeDay.WinChangeDay.transform);

        Text headerText = header.AddComponent<Text>();
        SetText.SetTextSettings(headerText, "Выберите нужный день", fontHeader, 60, new Color(0, 0.5245282f, 0.008282918f, 1), TextAnchor.MiddleCenter, FontStyle.Bold);

        RectTransform headerTransform = header.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(headerTransform, new Vector2(1000, 200), new Vector2(0.27f, 0.92f), new Vector2(0.27f, 0.92f));

        // поле ввода
        InputField = Instantiate(prefabInputField, transform.position, Quaternion.identity);
        InputField.transform.SetParent(CreateWinChangeDay.WinChangeDay.transform);

        RectTransform inputFieldTrnsform = InputField.GetComponent<RectTransform>();
        inputFieldTrnsform.localPosition = new Vector2(20, 100);

        InputText = InputField.GetComponent<InputField>();
        InputText.text = "0";
    }

    /// <summary>
    /// создание текста об неправельном вводе количества дней
    /// </summary>
    public void CreateTextError()
    {
        if (error != null) Destroy(error);  // если ошибка уже есть высветить ещё раз
        
        error = new GameObject("ErrorText");
        error.transform.SetParent(CreateWinChangeDay.WinChangeDay.transform);

        Text errorText = error.AddComponent<Text>();
        SetText.SetTextSettings(errorText, "", font, 50, Color.black, TextAnchor.MiddleCenter);
        StartCoroutine(PrintMsgInWindow.PrintMsg(errorText, "Введите число от 0 и до 99"));

        RectTransform errorTransform = error.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(errorTransform, new Vector2(1200, 200), new Vector2(0.5f, 0.4f), new Vector2(0.5f, 0.4f));
    }
}
