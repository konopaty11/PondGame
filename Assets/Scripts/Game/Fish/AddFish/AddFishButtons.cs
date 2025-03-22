using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using AFW = AddFishWindow;

public class AddFishButtons : MonoBehaviour
{
    [SerializeField] GameObject CountFishTextPrefab;    // ������ ������ � ���������� ��� �� �����

    // ������� ���
    [SerializeField] public GameObject prefabPerch;
    [SerializeField] public GameObject prefabPike;
    [SerializeField] public GameObject prefabCrucian;

    // ������������ ������� ���
    [SerializeField] GameObject parentPerch;
    [SerializeField] GameObject parentPike;
    [SerializeField] GameObject parentCrucian;

    [SerializeField] Sprite spriteBtnClose;     // ������ ������ �������� ���� ���������� ���

    [SerializeField] AudioClip btnClickClip;    // ���� ������� ������

    // ������� ������� � ���������� ��������� ��� ������� ����
    GameObject countPerchText;
    GameObject countPikeText;
    GameObject countCrucianText;

    // ������ � ��������� AudioSource
    PondManager canvas;     
    AudioSource canvasAudio;

    /// <summary>
    /// ������ ������ � ���� ���������� ���
    /// </summary>
    public void CreateButtonsWindow()
    {
        // ��������� ������� � ���������� AudioSource
        canvas = FindObjectOfType<PondManager>();
        canvasAudio = canvas.GetComponent<AudioSource>();

        // ������ �������� �����
        GameObject createPerch = new GameObject("ButtonCreatePerch");
        createPerch.transform.SetParent(AFW.window.transform);

        Button btnCreatePerch = createPerch.AddComponent<Button>();
        btnCreatePerch.onClick.AddListener(CreatePerch);

        Image perchImage = createPerch.AddComponent<Image>();
        perchImage.color = Color.clear;

        RectTransform perchTransform = createPerch.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(perchTransform, new Vector2(570, 275), new Vector2(0.82f, 0.72f), new Vector2(0.82f, 0.72f));

        // �������� ������ ���������� ��������� ������
        countPerchText = Instantiate(CountFishTextPrefab, transform.position, Quaternion.identity);
        countPerchText.transform.SetParent(createPerch.transform);
        CreateCountFish(countPerchText, new Vector2(0.08f, 0.82f));



        // ������ �������� ����
        GameObject createPike = new GameObject("ButtonCreatePike");
        createPike.transform.SetParent(AFW.window.transform);

        Button btnCreatePike = createPike.AddComponent<Button>();
        btnCreatePike.onClick.AddListener(CreatePike);

        Image pikeImage = createPike.AddComponent<Image>();
        pikeImage.color = Color.clear;

        RectTransform pikeTransform = createPike.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(pikeTransform, new Vector2(570, 275), new Vector2(0.82f, 0.445f), new Vector2(0.82f, 0.445f));

        // �������� ������ ���������� ��������� ���
        countPikeText = Instantiate(CountFishTextPrefab, transform.position, Quaternion.identity);
        countPikeText.transform.SetParent(createPike.transform);
        CreateCountFish(countPikeText, new Vector2(0.08f, 0.82f));



        // ������ �������� ������
        GameObject createCrucian = new GameObject("ButtonCreateCrusian");
        createCrucian.transform.SetParent(AFW.window.transform);

        Button btnCreateCrucian = createCrucian.AddComponent<Button>();
        btnCreateCrucian.onClick.AddListener(CreateCrucian);

        Image crucianImage = createCrucian.AddComponent<Image>();
        crucianImage.color = Color.clear;

        RectTransform crucianTransform = createCrucian.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(crucianTransform, new Vector2(570, 275), new Vector2(0.82f, 0.17f), new Vector2(0.82f, 0.17f));

        // �������� ������ ���������� ��������� �������
        countCrucianText = Instantiate(CountFishTextPrefab, transform.position, Quaternion.identity);
        countCrucianText.transform.SetParent(createCrucian.transform);
        CreateCountFish(countCrucianText, new Vector2(0.08f, 0.82f));



        // ������ �������� ����
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
    /// ��������� ��������� ������ � ����������� ��������� ���
    /// </summary>
    /// <param name="countFishText"> ������ ������ </param>
    /// <param name="anchor"> ����� </param>
    void CreateCountFish(GameObject countFishText, Vector2 anchor)
    {
        Text textCountFish = countFishText.GetComponent<Text>();

        RectTransform countFishTransform = countFishText.GetComponent<RectTransform>();
        countFishTransform.localPosition = new Vector2(0, 0);
        countFishTransform.anchorMin = anchor;
        countFishTransform.anchorMax = anchor;
    }

    /// <summary>
    /// ������ ������ ����� �� �����
    /// </summary>
    void CreatePerch()
    {
        if (Pond.CountCreatePerchs < 4)
        {
            canvasAudio.PlayOneShot(btnClickClip);  // ������ ����� ������� ������

            ManagerFish perch = FindObjectOfType<ManagerFish>();    // ���� ������ �� �������� ManagerFish
            perch.CreateFish(prefabPerch, parentPerch);             // �������� �����

            // ���������� ���������� ��������� ������
            Pond.CountPerchs++;
            countPerchText.GetComponent<Text>().text = Convert.ToString(++Pond.CountCreatePerchs);
        }
    }

    /// <summary>
    /// ������ ������ ���� �� �����
    /// </summary>
    void CreatePike()
    {
        if (Pond.CountCreatePikes < 4)
        {
            canvasAudio.PlayOneShot(btnClickClip);  // ������ ����� ������� ������

            // �������� ����
            ManagerFish pike = FindObjectOfType<ManagerFish>();
            pike.CreateFish(prefabPike, parentPike);

            // ���������� ���������� ��������� ���
            Pond.CountPikes++;
            countPikeText.GetComponent<Text>().text = Convert.ToString(++Pond.CountCreatePikes);
        }
    }

    /// <summary>
    /// ������ ������ ������ �� �����
    /// </summary>
    void CreateCrucian()
    {
        if (Pond.CountCreateCrucians < 4)
        {
            canvasAudio.PlayOneShot(btnClickClip);  // ������ ����� ������� ������

            // �������� ������
            ManagerFish crucian = FindObjectOfType<ManagerFish>();
            crucian.CreateFish(prefabCrucian, parentCrucian);

            // ���������� ���������� ��������� �������
            Pond.CountCrucians++;
            countCrucianText.GetComponent<Text>().text = Convert.ToString(++Pond.CountCreateCrucians);
        }
    }

    /// <summary>
        /// ������� �� ����
        /// </summary>
    void CloseWindow()
    {
        canvasAudio.PlayOneShot(btnClickClip);  // ������ ����� ������� ������
        Destroy(AFW.window);
    }
}