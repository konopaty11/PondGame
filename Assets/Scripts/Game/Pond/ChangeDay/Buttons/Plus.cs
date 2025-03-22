using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : MonoBehaviour
{
    /// <summary>
    /// прибавление счётчика пропуска дней на 1
    /// </summary>
    public void OnClick()
    {
        try
        {
            int days = 0;
            // если текст пустой ставить 0
            CreateTextChangeDay.InputText.text = CreateTextChangeDay.InputText.text == "" ? "0" : CreateTextChangeDay.InputText.text;

            // перевод значения в поле ввода в int и бросание исключения при неудачном переводе
            bool isInterger = int.TryParse(CreateTextChangeDay.InputText.text, out days) && days + 1 <= 99;
            if (!isInterger) throw new FormatException();

            // уменьешние значения поля ввода
            days++;
            CreateTextChangeDay.InputText.text = days.ToString();
        }
        catch (FormatException)
        {
            CreateTextChangeDay obj = FindObjectOfType<CreateTextChangeDay>();
            obj.CreateTextError();
        }
    }
}
