using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Exit : MonoBehaviour
{
    [SerializeField] Sprite spriteWindowQues;   // спрайт окна вопроса
    [SerializeField] Canvas canvas;
    [SerializeField] Font fontHeader;
    [SerializeField] Font fontText;
    [SerializeField] AudioClip btnClickAudio;   // звук нажатия на кнопку

    GameObject windowQues;  // объект окна вопроса

    AudioSource canvasAudioSource;  // компонент AudioSource канваса

    /// <summary>
    /// Создаёт пустышку и делает её сыном окна
    /// </summary>
    /// <param name="name"> название пустышки </param>
    /// <returns></returns>
    GameObject CreateGameObject(string name)
    {
        GameObject newObject = new GameObject(name);
        newObject.transform.SetParent(windowQues.transform);

        return newObject;
    }

    /// <summary>
    /// Создание окна
    /// </summary>
     public void CreateWindowQuesExit()
    {
        windowQues = new GameObject("ExitWindowQuestion");  
        windowQues.transform.SetParent(canvas.transform);   // наследование окна от canvas

        // накидывание спрайта
        Image windowImage = windowQues.AddComponent<Image>();   
        windowImage.sprite = spriteWindowQues;

        // настройка RectTransform
        RectTransform windowTransform = windowQues.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(windowTransform, new Vector2(1415, 861));
        
        CreateHeader();
    }

    /// <summary>
    /// Создаёт заголовок окна
    /// </summary>
     void CreateHeader()
    {
        GameObject windowHeader = CreateGameObject("WindowHeader"); 

        // настройка Text
        Text headerText = windowHeader.AddComponent<Text>();
        SetText.SetTextSettings(headerText, "Система", fontHeader, 60, Color.black, TextAnchor.MiddleCenter, FontStyle.Bold);

        // настройка RectTransform
        RectTransform headerTransform = windowHeader.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(headerTransform, new Vector2(500, 200), new Vector2(0.22f, 0.9f), new Vector2(0.22f, 0.9f));

        CreateText();
    }

    /// <summary>
    /// Создание основного текста окна
    /// </summary>
     void CreateText()
    {
        GameObject windowText = CreateGameObject("WindowText");

        // настройка Text
        Text text = windowText.AddComponent<Text>();
        SetText.SetTextSettings(text, "", fontText, 50, Color.black, TextAnchor.MiddleLeft);

        // Анимация печатанья текста
        string str = "Вы уверены, что хотите покинуть игру?";
        StartCoroutine(PrintMsgInWindow.PrintMsg(text, str));

        // настройка RectTransform
        RectTransform textTransform = windowText.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(textTransform, new Vector2(1070, 350), new Vector2(0.5f, 0.585f), new Vector2(0.5f, 0.585f));

        CreateButtons();
    }

    /// <summary>
    /// Создание кнопок Да/Нет
    /// </summary>
     void CreateButtons()
    {
        GameObject objectYes = CreateGameObject("ButtonYes");
        GameObject objectNo = CreateGameObject("ButtonNo");

        // настройка Text
        Text textYes = objectYes.AddComponent<Text>();
        Text textNo = objectNo.AddComponent<Text>();

        SetText.SetTextSettings(textYes, "Да", fontText, 100, Color.red, TextAnchor.MiddleLeft);
        SetText.SetTextSettings(textNo, "Нет", fontText, 100, Color.green, TextAnchor.MiddleLeft);


        RectTransform textYesTransform = objectYes.GetComponent<RectTransform>();
        RectTransform textNoTransform = objectNo.GetComponent<RectTransform>();

        SetRectTransform.SetTransformSettings(textYesTransform, new Vector2(250, 130), new Vector2(0.20f, 0.20f), new Vector2(0.20f, 0.20f));
        SetRectTransform.SetTransformSettings(textNoTransform, new Vector2(250, 130), new Vector2(0.85f, 0.20f), new Vector2(0.85f, 0.20f));

        // добавление компонента AudioSource
        canvasAudioSource = canvas.GetComponent<AudioSource>();

        // назначение клипа
        canvasAudioSource.clip = btnClickAudio;

        // добавление компонентов Button
        Button buttonYes = objectYes.AddComponent<Button>();
        Button buttonNo = objectNo.AddComponent<Button>();

        buttonYes.onClick.AddListener(GameExit);
        buttonNo.onClick.AddListener(Destroy);
    }

    /// <summary>
    /// Уничтожает окно и воспроизводит звук нажатия кнопки
    /// </summary> 
    void Destroy()
    {
        canvasAudioSource.PlayOneShot(btnClickAudio);
        Destroy(windowQues);
    }

    /// <summary>
    /// Закрывает приложение и воспроизводит звук нажатия кнопки
    /// </summary>
    void GameExit()
    {
        canvasAudioSource.PlayOneShot(btnClickAudio);
        Application.Quit();
    }
}
    
