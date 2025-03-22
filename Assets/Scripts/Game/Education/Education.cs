using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Education : MonoBehaviour
{
    [SerializeField] GameObject parentText;     // родитель текста
    [SerializeField] GameObject btnAddFish;     // объект кнопки добавить рыбу
    [SerializeField] GameObject btnChangeDay;   // объект кнопки сменить день


    /// <summary>
    /// при нажатии на пробел сдвинуть текст, камеру и показать кнопки
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Flags.IsSkipEducation)
        {
            Flags.IsSkipEducation = false;

            // трансформы текстов
            Transform[] texts = parentText.GetComponentsInChildren<Transform>();
       
            foreach (Transform text in texts)
                StartCoroutine(MoveText(text));

            StartCoroutine(MoveCamera());

            StartCoroutine(ShowBtn(btnAddFish));
            StartCoroutine(ShowBtn(btnChangeDay));
        }
    }

    /// <summary>
    /// увеличивает постепенно прозрачность кнопки
    /// </summary>
    /// <param name="btn"> кнопка </param>
    /// <returns> ждать 0.02с каждый кадр</returns>
    IEnumerator ShowBtn(GameObject btn)
    {
        yield return new WaitForSeconds(2f);

        btn.SetActive(true);    // активаци€ кнопки

        Image btnImage = btn.GetComponent<Image>();
        Text btnText = btn.GetComponentInChildren<Text>();

        // постепенное по€вление
        for (float i = 0; i < 1; i += 0.02f)
        {
            btnImage.color = new Color(0, 1, 0.09410262f, i);
            btnText.color = new Color(1, 1, 1, i);

            yield return new WaitForSeconds(0.02f);
        }
        Flags.IsReadySkipDay = true;
    }

    /// <summary>
    /// смещает камеру
    /// </summary>
    IEnumerator MoveCamera()
    {
        float xCam = Camera.main.transform.position.x;
        float yCam = Camera.main.transform.position.y;
        float zCam = Camera.main.transform.position.z;

        float time = 0; // врем€ прибавл€ющеес€ к ожиданию на кадр

        for (float i = xCam; i < 0; i += 0.1f)
        {
            if (-i < 1) time = (float) 0.050 * Mathf.Exp(-2.587f * (-i));

            Camera.main.transform.position = new Vector3(i, yCam, zCam);

            yield return new WaitForSeconds(0.005f + time);
        }
    }

    /// <summary>
    /// перемещение текста
    /// </summary>
    /// <param name="text"> трансформ текста </param>
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
