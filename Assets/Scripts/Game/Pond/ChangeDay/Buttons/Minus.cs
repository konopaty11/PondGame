using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Minus : MonoBehaviour
{
    /// <summary>
    /// уменьшение счётчика пропуска дней на 1
    /// </summary>
    public void OnClick()
    {
        try
        {
            
            int days = 0;
            // если текст пустой ставить 0
            CreateTextChangeDay.InputText.text = CreateTextChangeDay.InputText.text == "" ? "0" : CreateTextChangeDay.InputText.text;

            // перевод значения в поле ввода в int и бросание исключения при неудачном переводе
            bool isInterger = int.TryParse(CreateTextChangeDay.InputText.text, out days) && days - 1 >= 0;
            if (!isInterger) throw new FormatException();

            // уменьшение значения поля
            days--;
            CreateTextChangeDay.InputText.text = days.ToString();
        }
        catch (FormatException)
        {
            CreateTextChangeDay obj = FindObjectOfType<CreateTextChangeDay>();
            obj.CreateTextError();
        }
    }
}
