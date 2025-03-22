using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintMsgInWindow : MonoBehaviour
{
    /// <summary>
    /// посимвольно выводит сообщение
    /// </summary>
    /// <param name="text"> компонент текст </param>
    /// <param name="str"> выводимая строка </param>
    public static IEnumerator PrintMsg(Text text, string str)
    {
        foreach (char sym in str)
        {
            if (text == null) yield break;
            text.text += sym;

            yield return new WaitForSeconds(0.03f);
        }
    }
}

