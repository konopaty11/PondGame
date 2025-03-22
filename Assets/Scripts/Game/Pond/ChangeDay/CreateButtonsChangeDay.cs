using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using CTCD = CreateTextChangeDay;
using CWCD = CreateWinChangeDay;

public class CreateButtonsChangeDay : MonoBehaviour
{
    [SerializeField] GameObject prefabMinus;    // префаб кнопки +
    [SerializeField] GameObject prefabPlus;     // префаб кнопки -
    [SerializeField] Sprite spriteBtnClose;     // спрайт кнопки закрытия окна
    [SerializeField] Font font;                 // обычный шрифт
    [SerializeField] AudioClip btnClickClip;    // звук нажатия на кнопку

    // канвас и компонент AudioSource
    PondManager canvas;
    AudioSource canvasAudio;
    public void CreateButtons()
    {
        // получение канваса и компанента AudioSource
        canvas = FindObjectOfType<PondManager>();
        canvasAudio = canvas.GetComponent<AudioSource>();

        // минус убавляет кол-во дней на 1
        GameObject minus = Instantiate(prefabMinus, transform.position, Quaternion.identity);
        minus.transform.SetParent(CTCD.InputField.transform);

        RectTransform minusTransform = minus.GetComponent<RectTransform>();
        minusTransform.anchorMin = new Vector2(0.45f, 0.5f);
        minusTransform.anchorMax = new Vector2(0.45f, 0.5f);
        minusTransform.localPosition = new Vector2(-100, 0);

        // плюс увеличивает кол-во дней на 1
        GameObject plus = Instantiate(prefabPlus, transform.position, Quaternion.identity);
        plus.transform.SetParent(CTCD.InputField.transform);

        RectTransform plusTransform = plus.GetComponent<RectTransform>();
        plusTransform.anchorMin = new Vector2(0.55f, 0.5f);
        plusTransform.anchorMax = new Vector2(0.55f, 0.5f);
        plusTransform.localPosition = new Vector2(100, 0);

        // кнопка ок 
        GameObject OK = new GameObject("ButtonOK");
        OK.transform.SetParent(CWCD.WinChangeDay.transform);

        Text btnOKtext = OK.AddComponent<Text>();
        SetText.SetTextSettings(btnOKtext, "OK", font, 80, Color.black, TextAnchor.MiddleCenter);

        RectTransform btnOKtransform = OK.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(btnOKtransform, new Vector2(200, 125), new Vector2(0.515f, 0.1f), new Vector2(0.515f, 0.1f));

        Button btnOK = OK.AddComponent<Button>();
        btnOK.onClick.AddListener(SetDay);

        // кнопка закрытия окна
        GameObject closeWin = new GameObject("ButtonCloseWindow");
        closeWin.transform.SetParent(CWCD.WinChangeDay.transform);

        Image closeWinImage = closeWin.AddComponent<Image>();
        closeWinImage.sprite = spriteBtnClose;
        closeWinImage.color = new Color(0, 0.5245282f, 0.008282918f, 1);

        RectTransform closeWinTransform = closeWin.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(closeWinTransform, new Vector2(100, 100), new Vector2(0.94f, 0.92f), new Vector2(0.94f, 0.92f));

        Button btnCloseWin = closeWin.AddComponent<Button>();
        btnCloseWin.onClick.AddListener(Destroy);
    }

    /// <summary>
    /// проверяет валидность значения поля ввода
    /// </summary>
    void SetDay()
    {
        try
        {
            int days;
            // проверка на валидность и бросание исключения
            bool isInterger = int.TryParse(CreateTextChangeDay.InputText.text, out days) && days >= 0 && days <= 99;
            if (!isInterger) throw new FormatException();

            canvasAudio.PlayOneShot(btnClickClip);  // воспроизведение звука нажатия на кнопку
            PondManager.CountOfDays = days;         // получение из поля ввода значения
            Destroy(CWCD.WinChangeDay);
            canvas.SkipSomeDays();                  // запуск метода пропуска нескольких дней
        }
        catch (FormatException)
        {
            CreateTextChangeDay obj = FindObjectOfType<CreateTextChangeDay>();
            obj.CreateTextError();
        }
        
    }

    /// <summary>
    /// удаление окна смены дня
    /// </summary>
    void Destroy()
    {
        canvasAudio.PlayOneShot(btnClickClip);
        Destroy(CWCD.WinChangeDay);
    }
}
