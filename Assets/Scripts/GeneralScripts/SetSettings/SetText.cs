using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    /// <summary>
    /// Устанавливает настройки Text
    /// </summary>
    /// <param name="text"> объект компонента Text </param>
    /// <param name="msg"> содеражание </param>
    /// <param name="font"> шрифт </param>
    /// <param name="fontSize"> размер шрифта </param>
    /// <param name="color"> цвет </param>
    /// <param name="alignment"> выравнивание </param>
    /// <param name="fontStyle"> стиль шрифта </param>
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
