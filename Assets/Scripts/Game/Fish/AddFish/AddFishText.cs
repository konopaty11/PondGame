using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AFW = AddFishWindow;

public class AddFishText : MonoBehaviour
{
    [SerializeField] Font fontHeader;           // ����� ���������
    [SerializeField] public Font font;                 // ������� �����

    /// <summary>
    /// ������ ���� ����� � ���� ���������� ���
    /// </summary>
    public void CreateTextWindow()
    {
        // ���������
        GameObject header = new GameObject("Header");
        header.transform.SetParent(AFW.window.transform);

        Text headerText = header.AddComponent<Text>();
        string str = "������� ���� � ����";
        SetText.SetTextSettings(headerText, str, fontHeader, 60, new Color(0, 0.5245282f, 0.008282918f, 1), TextAnchor.MiddleCenter, FontStyle.Bold);

        RectTransform headerTransform = header.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(headerTransform, new Vector2(1000, 200), new Vector2(0.23f, 0.92f), new Vector2(0.23f, 0.92f));


        // �������� ����� �����
        GameObject textPerch = new GameObject("TextPerch");
        textPerch.transform.SetParent(AFW.window.transform);

        Text textAboutPerch = textPerch.AddComponent<Text>();
        SetText.SetTextSettings(textAboutPerch, "", font, 45, Color.black, TextAnchor.UpperLeft);

        str = "������ ����� - �������� ����, ���������� ������� � ������ � �������� ����";
        StartCoroutine(PrintMsgInWindow.PrintMsg(textAboutPerch, str));

        RectTransform textPerchTransform = textPerch.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textPerchTransform, new Vector2(1000, 200), new Vector2(0.32f, 0.72f), new Vector2(0.32f, 0.72f));


        // �������� ����� ����
        GameObject textPike = new GameObject("TextPike");
        textPike.transform.SetParent(AFW.window.transform);

        Text textAboutPike = textPike.AddComponent<Text>();
        SetText.SetTextSettings(textAboutPike, "", font, 45, Color.black, TextAnchor.UpperLeft);

        str = "���� ������������ - ������ ����� �� 35��, ������� � ������� � �������� �������";
        StartCoroutine(PrintMsgInWindow.PrintMsg(textAboutPike, str));


        RectTransform textPikeTransform = textPike.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textPikeTransform, new Vector2(1000, 200), new Vector2(0.32f, 0.45f), new Vector2(0.32f, 0.45f));


        // �������� ����� ������
        GameObject textCrucian = new GameObject("TextCrucian");
        textCrucian.transform.SetParent(AFW.window.transform);

        Text textAboutCrucian = textCrucian.AddComponent<Text>();
        SetText.SetTextSettings(textAboutCrucian, "", font, 45, Color.black, TextAnchor.UpperLeft);

        str = "������ - ���������� ����, �������� ���������� ����������� ������ �� ���, ������� � ���������� ����� � �����";
        StartCoroutine(PrintMsgInWindow.PrintMsg(textAboutCrucian, str));

        RectTransform textCrucianTransform = textCrucian.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textCrucianTransform, new Vector2(1000, 400), new Vector2(0.32f, 0.07f), new Vector2(0.32f, 0.07f));

    }
}
