using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UninvisibleGameObjects : MonoBehaviour
{
    /// <summary>
    /// ������� ��������
    /// </summary>
    public void Uninvisible()
    {
        StartCoroutine(DecreaseTransparency());
    }

    /// <summary>
    /// ���������� ��������� ������������ ��������
    /// </summary>
    /// <returns></returns>
    IEnumerator DecreaseTransparency()
    {
        SpriteRenderer[] prefabsSpriteRen = gameObject.GetComponentsInChildren<SpriteRenderer>();   // ������� ��������

        for (float i = 1; i >= 0; i -= 0.02f)
        {
            foreach (SpriteRenderer spriteRen in prefabsSpriteRen)
                if (spriteRen != null)
                {
                    Color color = spriteRen.color;
                    color.a = i;
                    spriteRen.color = color;
                }
            yield return new WaitForSeconds(0.001f);
        }
    }

    /// <summary>
    /// ����� ��������
    /// </summary>
    public void Invisible()
    {
        StartCoroutine(IncreaseTransparency());
    }

    /// <summary>
    /// ���������� ����������� ������������ ��������
    /// </summary>
    IEnumerator IncreaseTransparency()
    {
        SpriteRenderer[] prefabsSpriteRen = gameObject.GetComponentsInChildren<SpriteRenderer>();   // ������� ��������

        for (float i = 0; i <= 1; i += 0.02f)
        {
            foreach (SpriteRenderer spriteRen in prefabsSpriteRen)
                if (spriteRen != null)
                {
                    Color color = spriteRen.color;
                    color.a = i;
                    spriteRen.color = color;
                }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
