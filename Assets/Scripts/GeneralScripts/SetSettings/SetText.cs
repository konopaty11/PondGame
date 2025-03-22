using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    /// <summary>
    /// ������������� ��������� Text
    /// </summary>
    /// <param name="text"> ������ ���������� Text </param>
    /// <param name="msg"> ����������� </param>
    /// <param name="font"> ����� </param>
    /// <param name="fontSize"> ������ ������ </param>
    /// <param name="color"> ���� </param>
    /// <param name="alignment"> ������������ </param>
    /// <param name="fontStyle"> ����� ������ </param>
    public static void SetTextSettings(Text text, string msg, Font font, int fontSize, Color color, TextAnchor alignment, FontStyle fontStyle = FontStyle.Normal)
    {
        text.text = msg;
        text.font = font;
        text.fontSize = fontSize;
        text.color = color;
        text.alignment = alignment;
        text.fontStyle = fontStyle;
    }
}
