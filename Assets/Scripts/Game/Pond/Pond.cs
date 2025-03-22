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

    // ������������ �������� ���
    public static double MaxBiomassFish { get; set; } = rnd.Next(200, 270) / 10f;   

    // �������� ���
    static double biomassFish;
    public static double BiomassFish { get => biomassFish; set {
            if (value > MaxBiomassFish) biomassFish = MaxBiomassFish;
            else if (value < 0.001) biomassFish = 0;
            else biomassFish = value;
        } }

    // ������������ �������� �����
    public static double MaxBiomassFeed { get; set; } = rnd.Next(100, 150) / 10f;  

    // �������� �����
    static double biomassFeed;
    public static double BiomassFeed { get => biomassFeed; set { if (value <= MaxBiomassFeed && value >= 0) biomassFeed = value; } }

    // ���������� ���������
    public static int BiomassPlankton { get; set; }


    // ����� ���
    public static int AllFishes { get; set; }
    // ������������ ���������� ���
    static int countFishesMax = 4;

    // ���������� ������
    static int countPerchs = 0;
    public static int CountPerchs { get => countPerchs; set { if (value <= countFishesMax && value >= 0) countPerchs = value; } }
    // ���������� ��������� ������
    static int countCreatePerchs = 0;
    public static int CountCreatePerchs { get => countCreatePerchs; set { if (value <= countFishesMax && value >= 0) countCreatePerchs = value; } }

    // ���������� ���
    static int countPikes = 0;
    public static int CountPikes { get => countPikes; set { if (value <= countFishesMax && value >= 0) countPikes = value; } }
    // ���-�� ��������� ���
    static int countCreatePikes = 0;
    public static int CountCreatePikes { get => countCreatePikes; set { if (value <= countFishesMax && value >= 0) countCreatePikes = value; } }

    // ���-�� �������
    static int countCrucians = 0;
    public static int CountCrucians { get => countCrucians; set { if (value <= countFishesMax && value >= 0) countCrucians = value; } }
    // ���-�� ��������� �������
    static int countCreateCrucians = 0;
    public static int CountCreateCrucians { get => countCreateCrucians; set { if (value <= countFishesMax && value >= 0) countCreateCrucians = value; } }

    // ������ ����������
    public static GameObject[] Seaweed { get; set; } = new GameObject[15];

    /// <summary>
    /// �������� ����������
    /// </summary>
    /// <param name="prefabSeaweedRed"> ������ ������� ��������� </param>
    /// <param name="prefabSeaweedGreen"> ������ ������ ��������� </param>
    /// <param name="parent"> �������� ���������� </param>
    /// <param name="a"> ����� ����� </param>
    static public void CreateSeaweed(GameObject prefabSeaweedRed, GameObject prefabSeaweedGreen, GameObject parent, float a = 0)
    {
        // �������� ��������� � ������ 33%
        if (rnd.Next(0, 3) == 0 && biomassFeed + 1 <= MaxBiomassFeed)
        {
            BiomassPlankton++;
            BiomassFeed++;
        }

        // �������� ������� ���������
        if (biomassFeed + 1 <= MaxBiomassFeed)
            for (int i = 0; i < Seaweed.Length; i++)
                if (Seaweed[i] == null)
                {
                    GameObject seaweedRed = Instantiate(prefabSeaweedRed, new Vector2(rnd.Next(-60, 85) / 10f, -6.3f), Quaternion.identity);
                    seaweedRed.transform.SetParent(parent.transform);
                    Seaweed[i++] = seaweedRed;  // ���������� � ������ ����������
                    BiomassFeed++;              // �������� � �������� �����

                    SetVisibility(seaweedRed, a);

                    break;
                }

        // �������� ������ ���������
        if (biomassFeed + 1 <= MaxBiomassFeed)
            for (int i = 0; i < Seaweed.Length; i++)
                if (Seaweed[i] == null)
                {
                    GameObject seaweedGreen = Instantiate(prefabSeaweedGreen, new Vector2(rnd.Next(-60, 85) / 10f, -6.3f), Quaternion.identity);
                    seaweedGreen.transform.SetParent(parent.transform);
                    Seaweed[i++] = seaweedGreen;  // ���������� � ������ ����������
                    BiomassFeed++;                // �������� � �������� �����

                    SetVisibility(seaweedGreen, a);

                    break;
                }
    }

    /// <summary>
    /// ������������ ������������ ���������
    /// </summary>
    /// <param name="seaweed"> ���������� </param>
    /// <param name="a"> ����� ����� </param>
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
