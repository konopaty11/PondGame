using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using CTCD = CreateTextChangeDay;
using CWCD = CreateWinChangeDay;

public class CreateButtonsChangeDay : MonoBehaviour
{
    [SerializeField] GameObject prefabMinus;    // ������ ������ +
    [SerializeField] GameObject prefabPlus;     // ������ ������ -
    [SerializeField] Sprite spriteBtnClose;     // ������ ������ �������� ����
    [SerializeField] Font font;                 // ������� �����
    [SerializeField] AudioClip btnClickClip;    // ���� ������� �� ������

    // ������ � ��������� AudioSource
    PondManager canvas;
    AudioSource canvasAudio;
    public void CreateButtons()
    {
        // ��������� ������� � ���������� AudioSource
        canvas = FindObjectOfType<PondManager>();
        canvasAudio = canvas.GetComponent<AudioSource>();

        // ����� �������� ���-�� ���� �� 1
        GameObject minus = Instantiate(prefabMinus, transform.position, Quaternion.identity);
        minus.transform.SetParent(CTCD.InputField.transform);

        RectTransform minusTransform = minus.GetComponent<RectTransform>();
        minusTransform.anchorMin = new Vector2(0.45f, 0.5f);
        minusTransform.anchorMax = new Vector2(0.45f, 0.5f);
        minusTransform.localPosition = new Vector2(-100, 0);

        // ���� ����������� ���-�� ���� �� 1
        GameObject plus = Instantiate(prefabPlus, transform.position, Quaternion.identity);
        plus.transform.SetParent(CTCD.InputField.transform);

        RectTransform plusTransform = plus.GetComponent<RectTransform>();
        plusTransform.anchorMin = new Vector2(0.55f, 0.5f);
        plusTransform.anchorMax = new Vector2(0.55f, 0.5f);
        plusTransform.localPosition = new Vector2(100, 0);

        // ������ �� 
        GameObject OK = new GameObject("ButtonOK");
        OK.transform.SetParent(CWCD.WinChangeDay.transform);

        Text btnOKtext = OK.AddComponent<Text>();
        SetText.SetTextSettings(btnOKtext, "OK", font, 80, Color.black, TextAnchor.MiddleCenter);

        RectTransform btnOKtransform = OK.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(btnOKtransform, new Vector2(200, 125), new Vector2(0.515f, 0.1f), new Vector2(0.515f, 0.1f));

        Button btnOK = OK.AddComponent<Button>();
        btnOK.onClick.AddListener(SetDay);

        // ������ �������� ����
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
    /// ��������� ���������� �������� ���� �����
    /// </summary>
    void SetDay()
    {
        try
        {
            int days;
            // �������� �� ���������� � �������� ����������
            bool isInterger = int.TryParse(CreateTextChangeDay.InputText.text, out days) && days >= 0 && days <= 99;
            if (!isInterger) throw new FormatException();

            canvasAudio.PlayOneShot(btnClickClip);  // ��������������� ����� ������� �� ������
            PondManager.CountOfDays = days;         // ��������� �� ���� ����� ��������
            Destroy(CWCD.WinChangeDay);
            canvas.SkipSomeDays();                  // ������ ������ �������� ���������� ����
        }
        catch (FormatException)
        {
            CreateTextChangeDay obj = FindObjectOfType<CreateTextChangeDay>();
            obj.CreateTextError();
        }
        
    }

    /// <summary>
    /// �������� ���� ����� ���
    /// </summary>
    void Destroy()
    {
        canvasAudio.PlayOneShot(btnClickClip);
        Destroy(CWCD.WinChangeDay);
    }
}
