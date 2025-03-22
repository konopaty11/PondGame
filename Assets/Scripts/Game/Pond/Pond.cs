using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Pond : MonoBehaviour
{
    static System.Random rnd = new System.Random();

    // максимальная биомасса рыб
    public static double MaxBiomassFish { get; set; } = rnd.Next(200, 270) / 10f;   

    // биомасса рыб
    static double biomassFish;
    public static double BiomassFish { get => biomassFish; set {
            if (value > MaxBiomassFish) biomassFish = MaxBiomassFish;
            else if (value < 0.001) biomassFish = 0;
            else biomassFish = value;
        } }

    // максимальная биомасса корма
    public static double MaxBiomassFeed { get; set; } = rnd.Next(100, 150) / 10f;  

    // биомасса корма
    static double biomassFeed;
    public static double BiomassFeed { get => biomassFeed; set { if (value <= MaxBiomassFeed && value >= 0) biomassFeed = value; } }

    // количество планктона
    public static int BiomassPlankton { get; set; }


    // всего рыб
    public static int AllFishes { get; set; }
    // максимальное количество рыб
    static int countFishesMax = 4;

    // количество окуней
    static int countPerchs = 0;
    public static int CountPerchs { get => countPerchs; set { if (value <= countFishesMax && value >= 0) countPerchs = value; } }
    // количество созданных окуней
    static int countCreatePerchs = 0;
    public static int CountCreatePerchs { get => countCreatePerchs; set { if (value <= countFishesMax && value >= 0) countCreatePerchs = value; } }

    // количество щук
    static int countPikes = 0;
    public static int CountPikes { get => countPikes; set { if (value <= countFishesMax && value >= 0) countPikes = value; } }
    // кол-во созданных щук
    static int countCreatePikes = 0;
    public static int CountCreatePikes { get => countCreatePikes; set { if (value <= countFishesMax && value >= 0) countCreatePikes = value; } }

    // кол-во карасей
    static int countCrucians = 0;
    public static int CountCrucians { get => countCrucians; set { if (value <= countFishesMax && value >= 0) countCrucians = value; } }
    // кол-во созданных карасей
    static int countCreateCrucians = 0;
    public static int CountCreateCrucians { get => countCreateCrucians; set { if (value <= countFishesMax && value >= 0) countCreateCrucians = value; } }

    // массив водорослей
    public static GameObject[] Seaweed { get; set; } = new GameObject[15];

    /// <summary>
    /// создание водорослей
    /// </summary>
    /// <param name="prefabSeaweedRed"> префаб красной водоросли </param>
    /// <param name="prefabSeaweedGreen"> префаб зелёной водоросли </param>
    /// <param name="parent"> родитель водорослей </param>
    /// <param name="a"> альфа канал </param>
    static public void CreateSeaweed(GameObject prefabSeaweedRed, GameObject prefabSeaweedGreen, GameObject parent, float a = 0)
    {
        // создание планктона с шансом 33%
        if (rnd.Next(0, 3) == 0 && biomassFeed + 1 <= MaxBiomassFeed)
        {
            BiomassPlankton++;
            BiomassFeed++;
        }

        // создание красной водоросли
        if (biomassFeed + 1 <= MaxBiomassFeed)
            for (int i = 0; i < Seaweed.Length; i++)
                if (Seaweed[i] == null)
                {
                    GameObject seaweedRed = Instantiate(prefabSeaweedRed, new Vector2(rnd.Next(-60, 85) / 10f, -6.3f), Quaternion.identity);
                    seaweedRed.transform.SetParent(parent.transform);
                    Seaweed[i++] = seaweedRed;  // добавление в массив водорослей
                    BiomassFeed++;              // прибавка к биомассе корма

                    SetVisibility(seaweedRed, a);

                    break;
                }

        // создание зелёной водоросли
        if (biomassFeed + 1 <= MaxBiomassFeed)
            for (int i = 0; i < Seaweed.Length; i++)
                if (Seaweed[i] == null)
                {
                    GameObject seaweedGreen = Instantiate(prefabSeaweedGreen, new Vector2(rnd.Next(-60, 85) / 10f, -6.3f), Quaternion.identity);
                    seaweedGreen.transform.SetParent(parent.transform);
                    Seaweed[i++] = seaweedGreen;  // добавление в массив водорослей
                    BiomassFeed++;                // прибавка к биомассе корма

                    SetVisibility(seaweedGreen, a);

                    break;
                }
    }

    /// <summary>
    /// установление прозрачности водоросли
    /// </summary>
    /// <param name="seaweed"> водоросоль </param>
    /// <param name="a"> альфа канал </param>
    static void SetVisibility(GameObject seaweed, float a)
    {
        SpriteRenderer[] seaweedSpriteRen = seaweed.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRen in seaweedSpriteRen)
        {
            Color color = spriteRen.color;
            color.a = a;
            spriteRen.color = color;
        }
    }

}
