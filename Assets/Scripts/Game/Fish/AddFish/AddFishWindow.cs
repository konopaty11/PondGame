using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddFishWindow : MonoBehaviour
{
    [SerializeField] Canvas canvas;             // канвас
    [SerializeField] Sprite spriteWindow;       // спрайт окна добавления рыб

    

    // объект окна
    public static GameObject window;

    /// <summary>
    /// Создаёт окно добавления рыб и присваивает ему спрайт
    /// </summary>
    public void CreateWindow()
    {
        window = new GameObject("AddFishWindow");
        window.transform.SetParent(canvas.transform);

        Image windowImage = window.AddComponent<Image>();
        windowImage.sprite = spriteWindow;

        RectTransform windowTransform = window.GetComponent<RectTransform>();
        SetRectTransform.SetTransformSettings(windowTransform, new Vector2(1800f, 1045f));
    }
}
