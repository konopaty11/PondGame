using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using AFW = AddFishWindow;

public class AddFishButtons : MonoBehaviour
{
    [SerializeField] GameObject CountFishTextPrefab;    // префаб текста о количестве рыб на сцене

    // префабы рыб
    [SerializeField] public GameObject prefabPerch;
    [SerializeField] public GameObject prefabPike;
    [SerializeField] public GameObject prefabCrucian;

    // родительские объекты рыб
    [SerializeField] GameObject parentPerch;
    [SerializeField] GameObject parentPike;
    [SerializeField] GameObject parentCrucian;

    [SerializeField] Sprite spriteBtnClose;     // спрайт кнопки закрытия окна добавления рыб

    [SerializeField] AudioClip btnClickClip;    // звук нажатия кнопки

    // объекты текстов о количестве созданных рыб каждого вида
    GameObject countPerchText;
    GameObject countPikeText;
    GameObject countCrucianText;

    // канвас и компонент AudioSource
    PondManager canvas;     
    AudioSource canvasAudio;

    /// <summary>
    /// Создаёт кнопки в окне добавления рыб
    /// </summary>
    public void CreateButtonsWindow()
    {
        // получение канваса и компанента AudioSource
        canvas = FindObjectOfType<PondManager>();
        canvasAudio = canvas.GetComponent<AudioSource>();

        // кнопка создания окуня
        GameObject createPerch = new GameObject("ButtonCreatePerch");
        createPerch.transform.SetParent(AFW.window.transform);

        Button btnCreatePerch = createPerch.AddComponent<Button>();
        btnCreatePerch.onClick.AddListener(CreatePerch);

        Image perchImage = createPerch.AddComponent<Image>();
        perchImage.color = Color.clear;

        RectTransform perchTransform = createPerch.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(perchTransform, new Vector2(570, 275), new Vector2(0.82f, 0.72f), new Vector2(0.82f, 0.72f));

        // создание текста количества созданных окуней
        countPerchText = Instantiate(CountFishTextPrefab, transform.position, Quaternion.identity);
        countPerchText.transform.SetParent(createPerch.transform);
        CreateCountFish(countPerchText, new Vector2(0.08f, 0.82f));



        // кнопка создания щуки
        GameObject createPike = new GameObject("ButtonCreatePike");
        createPike.transform.SetParent(AFW.window.transform);

        Button btnCreatePike = createPike.AddComponent<Button>();
        btnCreatePike.onClick.AddListener(CreatePike);

        Image pikeImage = createPike.AddComponent<Image>();
        pikeImage.color = Color.clear;

        RectTransform pikeTransform = createPike.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(pikeTransform, new Vector2(570, 275), new Vector2(0.82f, 0.445f), new Vector2(0.82f, 0.445f));

        // создание текста количества созданных щук
        countPikeText = Instantiate(CountFishTextPrefab, transform.position, Quaternion.identity);
        countPikeText.transform.SetParent(createPike.transform);
        CreateCountFish(countPikeText, new Vector2(0.08f, 0.82f));



        // кнопка создания карася
        GameObject createCrucian = new GameObject("ButtonCreateCrusian");
        createCrucian.transform.SetParent(AFW.window.transform);

        Button btnCreateCrucian = createCrucian.AddComponent<Button>();
        btnCreateCrucian.onClick.AddListener(CreateCrucian);

        Image crucianImage = createCrucian.AddComponent<Image>();
        crucianImage.color = Color.clear;

        RectTransform crucianTransform = createCrucian.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(crucianTransform, new Vector2(570, 275), new Vector2(0.82f, 0.17f), new Vector2(0.82f, 0.17f));

        // создание текста количества созданных карасей
        countCrucianText = Instantiate(CountFishTextPrefab, transform.position, Quaternion.identity);
        countCrucianText.transform.SetParent(createCrucian.transform);
        CreateCountFish(countCrucianText, new Vector2(0.08f, 0.82f));



        // кнопка закрытия окна
        GameObject closeWindow = new GameObject("ButtonCloseWindow");
        closeWindow.transform.SetParent(AFW.window.transform);

        Image closeWindowImage = closeWindow.AddComponent<Image>();
        closeWindowImage.sprite = spriteBtnClose;
        closeWindowImage.color = new Color(0, 0.5245282f, 0.008282918f, 1);

        RectTransform closeWindowTransform = closeWindow.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(closeWindowTransform, new Vector2(100, 100), new Vector2(0.94f, 0.92f), new Vector2(0.94f, 0.92f));

        Button btnCloseWindow = closeWindow.AddComponent<Button>();
        btnCloseWindow.onClick.AddListener(CloseWindow);
    }

    /// <summary>
    /// размещает созданные тексты о количествах созданных рыб
    /// </summary>
    /// <param name="countFishText"> объект текста </param>
    /// <param name="anchor"> якори </param>
    void CreateCountFish(GameObject countFishText, Vector2 anchor)
    {
        Text textCountFish = countFishText.GetComponent<Text>();

        RectTransform countFishTransform = countFishText.GetComponent<RectTransform>();
        countFishTransform.localPosition = new Vector2(0, 0);
        countFishTransform.anchorMin = anchor;
        countFishTransform.anchorMax = anchor;
    }

    /// <summary>
    /// Создаёт префаб окуня на сцене
    /// </summary>
    void CreatePerch()
    {
        if (Pond.CountCreatePerchs < 4)
        {
            canvasAudio.PlayOneShot(btnClickClip);  // запуск звука нажатия кнопки

            ManagerFish perch = FindObjectOfType<ManagerFish>();    // ищет объект со скриптом ManagerFish
            perch.CreateFish(prefabPerch, parentPerch);             // создание окуня

            // обновление количества созданных окуней
            Pond.CountPerchs++;
            countPerchText.GetComponent<Text>().text = Convert.ToString(++Pond.CountCreatePerchs);
        }
    }

    /// <summary>
    /// Создаёт префаб щуки на сцене
    /// </summary>
    void CreatePike()
    {
        if (Pond.CountCreatePikes < 4)
        {
            canvasAudio.PlayOneShot(btnClickClip);  // запуск звука нажатия кнопки

            // создание щуки
            ManagerFish pike = FindObjectOfType<ManagerFish>();
            pike.CreateFish(prefabPike, parentPike);

            // обновление количества созданных щук
            Pond.CountPikes++;
            countPikeText.GetComponent<Text>().text = Convert.ToString(++Pond.CountCreatePikes);
        }
    }

    /// <summary>
    /// Создаёт префаб карася на сцене
    /// </summary>
    void CreateCrucian()
    {
        if (Pond.CountCreateCrucians < 4)
        {
            canvasAudio.PlayOneShot(btnClickClip);  // запуск звука нажатия кнопки

            // создание карася
            ManagerFish crucian = FindObjectOfType<ManagerFish>();
            crucian.CreateFish(prefabCrucian, parentCrucian);

            // обновление количества созданных карасей
            Pond.CountCrucians++;
            countCrucianText.GetComponent<Text>().text = Convert.ToString(++Pond.CountCreateCrucians);
        }
    }

    /// <summary>
        /// удаляет всё окно
        /// </summary>
    void CloseWindow()
    {
        canvasAudio.PlayOneShot(btnClickClip);  // запуск звука нажатия кнопки
        Destroy(AFW.window);
    }
}