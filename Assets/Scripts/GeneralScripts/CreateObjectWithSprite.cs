using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObjectWithSprite : MonoBehaviour
{
    /// <summary>
    /// Создаёт объект, наследует его от родителя,
    /// добавляет компанент Image и устанавливает спрайт
    /// </summary>
    /// <param name="name"> имя объекта </param>
    /// <param name="parent"> объект родителя </param>
    /// <param name="sprite"> спрайт объекта </param>
    /// <returns> созданный объект </returns>
    public static GameObject CreateSprite(string name, Sprite sprite, GameObject parent = null)
    {
        GameObject body = new GameObject(name);
        if (parent != null) body.transform.SetParent(parent.transform);

        Image bodyImage = body.AddComponent<Image>();
        bodyImage.sprite = sprite;

        return body;
    }
}
