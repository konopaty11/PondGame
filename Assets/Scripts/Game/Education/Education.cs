using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Education : MonoBehaviour
{
    [SerializeField] GameObject parentText;     // �������� ������
    [SerializeField] GameObject btnAddFish;     // ������ ������ �������� ����
    [SerializeField] GameObject btnChangeDay;   // ������ ������ ������� ����


    /// <summary>
    /// ��� ������� �� ������ �������� �����, ������ � �������� ������
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Flags.IsSkipEducation)
        {
            Flags.IsSkipEducation = false;

            // ���������� �������
            Transform[] texts = parentText.GetComponentsInChildren<Transform>();
       
            foreach (Transform text in texts)
                StartCoroutine(MoveText(text));

            StartCoroutine(MoveCamera());

            StartCoroutine(ShowBtn(btnAddFish));
            StartCoroutine(ShowBtn(btnChangeDay));
        }
    }

    /// <summary>
    /// ����������� ���������� ������������ ������
    /// </summary>
    /// <param name="btn"> ������ </param>
    /// <returns> ����� 0.02� ������ ����</returns>
    IEnumerator ShowBtn(GameObject btn)
    {
        yield return new WaitForSeconds(2f);

        btn.SetActive(true);    // ��������� ������

        Image btnImage = btn.GetComponent<Image>();
        Text btnText = btn.GetComponentInChildren<Text>();

        // ����������� ���������
        for (float i = 0; i < 1; i += 0.02f)
        {
            btnImage.color = new Color(0, 1, 0.09410262f, i);
            btnText.color = new Color(1, 1, 1, i);

            yield return new WaitForSeconds(0.02f);
        }
        Flags.IsReadySkipDay = true;
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    IEnumerator MoveCamera()
    {
        float xCam = Camera.main.transform.position.x;
        float yCam = Camera.main.transform.position.y;
        float zCam = Camera.main.transform.position.z;

        float time = 0; // ����� �������������� � �������� �� ����

        for (float i = xCam; i < 0; i += 0.1f)
        {
            if (-i < 1) time = (float) 0.050 * Mathf.Exp(-2.587f * (-i));

            Camera.main.transform.position = new Vector3(i, yCam, zCam);

            yield return new WaitForSeconds(0.005f + time);
        }
    }

    /// <summary>
    /// ����������� ������
    /// </summary>
    /// <param name="text"> ��������� ������ </param>
    IEnumerator MoveText(Transform text)
    {
        float xText = text.transform.position.x;
        float yText = text.transform.position.y;
        float zText = text.transform.position.z;

        for (float i = xText; i >= -730; i -= 10.6f)
        {
            text.transform.position = new Vector3(i, yText, zText);
            yield return new WaitForSeconds(0.005f);
        }

    }
}
