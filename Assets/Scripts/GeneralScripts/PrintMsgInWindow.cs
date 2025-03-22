using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintMsgInWindow : MonoBehaviour
{
    /// <summary>
    /// ����������� ������� ���������
    /// </summary>
    /// <param name="text"> ��������� ����� </param>
    /// <param name="str"> ��������� ������ </param>
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

