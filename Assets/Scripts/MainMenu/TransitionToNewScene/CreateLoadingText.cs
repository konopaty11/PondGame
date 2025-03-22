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
        loadingTextObject = new GameObject("LoadingText");          // �������� ��������
        loadingTextObject.transform.SetParent(canvas.transform);    // ����������� ������������ �������� �� �������


        // ���������� � �������� ��������� Text
        loadingText = loadingTextObject.AddComponent<Text>();

        // �������������� ������
        loadingText.text = "��������";
        loadingText.alignment = TextAnchor.MiddleCenter;
        loadingText.font = font;
        loadingText.fontSize = 150;


        // ���������� ���������� transform
        RectTransform loadingTextTransform = loadingText.GetComponent<RectTransform>();

        // ��������� ������
        loadingTextTransform.offsetMax = new Vector2(0.5f, 0.5f);
        loadingTextTransform.offsetMin = new Vector2(0.5f, 0.5f);

        // ������� ������������ ������
        loadingTextTransform.anchoredPosition = Vector2.zero;
        // ������ ���������� ����
        loadingTextTransform.sizeDelta = new Vector2(1000, 400);


        // ����� �������
        StartCoroutine(Apperance());
        StartCoroutine(Animation());
    }

    /// <summary>
    /// ������ ������� ����� �������� �� �����
    /// </summary>
    /// <returns></returns>
    IEnumerator Apperance()
    {
        // ���������� �����
        loadingText.color = Color.clear;

        // ����������� ���������
        for(float i = 0; i < 1; i += 0.02f)
        {
            loadingText.color = new Color(0, 0, 0, i);

            yield return new WaitForSeconds(0.02f);
        }
    }

    /// <summary>
    /// ��������� ����� ��������
    /// </summary>
    /// <returns></returns>
    IEnumerator Animation()
    {
        string primaryText = loadingText.text;  // ��������� �����
        // �������� ��������
        for(int i = 8; i > 0; i--)
        {
            if (i % 4 == 0) loadingText.text = primaryText;
            else loadingText.text += ".";

            yield return new WaitForSeconds(0.33f);
        }

        // �������� ����� �����
        LoadScene();
    }

    /// <summary>
    /// ��������� ����� Game
    /// </summary>
    void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
