using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Minus : MonoBehaviour
{
    /// <summary>
    /// ���������� �������� �������� ���� �� 1
    /// </summary>
    public void OnClick()
    {
        try
        {
            
            int days = 0;
            // ���� ����� ������ ������� 0
            CreateTextChangeDay.InputText.text = CreateTextChangeDay.InputText.text == "" ? "0" : CreateTextChangeDay.InputText.text;

            // ������� �������� � ���� ����� � int � �������� ���������� ��� ��������� ��������
            bool isInterger = int.TryParse(CreateTextChangeDay.InputText.text, out days) && days - 1 >= 0;
            if (!isInterger) throw new FormatException();

            // ���������� �������� ����
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
