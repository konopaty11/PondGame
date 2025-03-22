using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UninvisibleGameObjects : MonoBehaviour
{
    /// <summary>
    /// скрытие префабов
    /// </summary>
    public void Uninvisible()
    {
        StartCoroutine(DecreaseTransparency());
    }

    /// <summary>
    /// постепенно уменьшает прозрачность префабов
    /// </summary>
    /// <returns></returns>
    IEnumerator DecreaseTransparency()
    {
        SpriteRenderer[] prefabsSpriteRen = gameObject.GetComponentsInChildren<SpriteRenderer>();   // спрайты префабов

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
    /// показ префабов
    /// </summary>
    public void Invisible()
    {
        StartCoroutine(IncreaseTransparency());
    }

    /// <summary>
    /// постепенно увеличивает прозрачность префабов
    /// </summary>
    IEnumerator IncreaseTransparency()
    {
        SpriteRenderer[] prefabsSpriteRen = gameObject.GetComponentsInChildren<SpriteRenderer>();   // спрайты префабов

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
