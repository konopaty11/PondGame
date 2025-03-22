using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerFish : MonoBehaviour
{
    public static GameObject[] Fishes { get; private set; } = new GameObject[12];   // ������ �������� ���

    public static GameObject Fish { get => Fishes[i]; } // ���������� �������� ����
    static int i;   // ������ �������� ����

    static System.Random rnd = new System.Random();

    /// <summary>
    /// ������ ���� � ��������� � ������ ���
    /// </summary>
    /// <param name="prefabFish"> ������ ���� </param>
    /// <param name="parent"> �������� ���� </param>
    public void CreateFish(GameObject prefabFish, GameObject parent)
    {
            GameObject fish = Instantiate(prefabFish, new Vector2(rnd.Next(-7, 8), rnd.Next(-4, 2)), Quaternion.identity);
            fish.transform.SetParent(parent.transform);

            Fishes[++i] = fish;
            Pond.AllFishes++;
    }

    /// <summary>
    /// ������������� null ������� ��� ��� ������ ������� �����
    /// </summary>
    void Start()
    {
        i = -1;
        for (int j = 0; j < 12; j++)
            Fishes[j] = null;
    }

    /// <summary>
    /// �������� ���������� ������ ����
    /// </summary>
    void Update()
    {
        // ��� ������� Q ����� �� �������� ���� ��������� ����� � �������
        if (Input.GetKeyDown(KeyCode.Q) && i > 0)
            for (int j = --i; j >= 0; j--)
            {
                if (Fishes[j] != null)
                {
                    i = j;
                    break;
                }
                else if (j == 0) i++;
            }

        // ��� ������� E ����� �� �������� ���� ��������� ������ � �������
        if (Input.GetKeyDown(KeyCode.E) && i + 1 < Pond.AllFishes)
            for (int j = ++i; j < Pond.AllFishes; j++)
            {
                if (Fishes[j] != null)
                {
                    i = j;
                    break;
                }
                else if (j == Pond.AllFishes - 1) i--;
            }
    }
}
