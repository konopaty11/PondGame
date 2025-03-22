using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Exit : MonoBehaviour
{
    [SerializeField] Sprite spriteWindowQues;   // ������ ���� �������
    [SerializeField] Canvas canvas;
    [SerializeField] Font fontHeader;
    [SerializeField] Font fontText;
    [SerializeField] AudioClip btnClickAudio;   // ���� ������� �� ������

    GameObject windowQues;  // ������ ���� �������

    AudioSource canvasAudioSource;  // ��������� AudioSource �������

    /// <summary>
    /// ������ �������� � ������ � ����� ����
    /// </summary>
    /// <param name="name"> �������� �������� </param>
    /// <returns></returns>
    GameObject CreateGameObject(string name)
    {
        GameObject newObject = new GameObject(name);
        newObject.transform.SetParent(windowQues.transform);

        return newObject;
    }

    /// <summary>
    /// �������� ����
    /// </summary>
     public void CreateWindowQuesExit()
    {
        windowQues = new GameObject("ExitWindowQuestion");  
        windowQues.transform.SetParent(canvas.transform);   // ������������ ���� �� canvas

        // ����������� �������
        Image windowImage = windowQues.AddComponent<Image>();   
        windowImage.sprite = spriteWindowQues;

        // ��������� RectTransform
        RectTransform windowTransform = windowQues.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(windowTransform, new Vector2(1415, 861));
        
        CreateHeader();
    }

    /// <summary>
    /// ������ ��������� ����
    /// </summary>
     void CreateHeader()
    {
        GameObject windowHeader = CreateGameObject("WindowHeader"); 

        // ��������� Text
        Text headerText = windowHeader.AddComponent<Text>();
        SetText.SetTextSettings(headerText, "�������", fontHeader, 60, Color.black, TextAnchor.MiddleCenter, FontStyle.Bold);

        // ��������� RectTransform
        RectTransform headerTransform = windowHeader.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(headerTransform, new Vector2(500, 200), new Vector2(0.22f, 0.9f), new Vector2(0.22f, 0.9f));

        CreateText();
    }

    /// <summary>
    /// �������� ��������� ������ ����
    /// </summary>
     void CreateText()
    {
        GameObject windowText = CreateGameObject("WindowText");

        // ��������� Text
        Text text = windowText.AddComponent<Text>();
        SetText.SetTextSettings(text, "", fontText, 50, Color.black, TextAnchor.MiddleLeft);

        // �������� ��������� ������
        string str = "�� �������, ��� ������ �������� ����?";
        StartCoroutine(PrintMsgInWindow.PrintMsg(text, str));

        // ��������� RectTransform
        RectTransform textTransform = windowText.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textTransform, new Vector2(1070, 350), new Vector2(0.5f, 0.585f), new Vector2(0.5f, 0.585f));

        CreateButtons();
    }

    /// <summary>
    /// �������� ������ ��/���
    /// </summary>
     void CreateButtons()
    {
        GameObject objectYes = CreateGameObject("ButtonYes");
        GameObject objectNo = CreateGameObject("ButtonNo");

        // ��������� Text
        Text textYes = objectYes.AddComponent<Text>();
        Text textNo = objectNo.AddComponent<Text>();

        SetText.SetTextSettings(textYes, "��", fontText, 100, Color.red, TextAnchor.MiddleLeft);
        SetText.SetTextSettings(textNo, "���", fontText, 100, Color.green, TextAnchor.MiddleLeft);


        RectTransform textYesTransform = objectYes.GetComponent<RectTransform>();
        RectTransform textNoTransform = objectNo.GetComponent<RectTransform>();

        SetRectTransform.SetTransformSettings(textYesTransform, new Vector2(250, 130), new Vector2(0.20f, 0.20f), new Vector2(0.20f, 0.20f));
        SetRectTransform.SetTransformSettings(textNoTransform, new Vector2(250, 130), new Vector2(0.85f, 0.20f), new Vector2(0.85f, 0.20f));

        // ���������� ���������� AudioSource
        canvasAudioSource = canvas.GetComponent<AudioSource>();

        // ���������� �����
        canvasAudioSource.clip = btnClickAudio;

        // ���������� ����������� Button
        Button buttonYes = objectYes.AddComponent<Button>();
        Button buttonNo = objectNo.AddComponent<Button>();

        buttonYes.onClick.AddListener(GameExit);
        buttonNo.onClick.AddListener(Destroy);
    }

    /// <summary>
    /// ���������� ���� � ������������� ���� ������� ������
    /// </summary> 
    void Destroy()
    {
        canvasAudioSource.PlayOneShot(btnClickAudio);
        Destroy(windowQues);
    }

    /// <summary>
    /// ��������� ���������� � ������������� ���� ������� ������
    /// </summary>
    void GameExit()
    {
        canvasAudioSource.PlayOneShot(btnClickAudio);
        Application.Quit();
    }
}
    
