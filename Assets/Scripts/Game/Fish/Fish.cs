using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    static public Animator Animator { get; private set; }     // ��������

    static GameObject fish;     // �������� ����

    // ���� ����
    public double Weight { get; set; } = 0; // ���
    public double ProcMassFish { get; set; }    // ������� ����� ���� �� ����� ������
    public double ProcMassFeed { get; set; }    // ������� ����� ���� �� ����� �����
    protected int age = 0;  // ��������
    protected int ageMax;   // ������������ ��������

    protected int dayOfStarvation = 0;  // ���� ���������
    protected int dayOfStarvationMax;   // �������� ���� ��� ���

    public bool IsHerbivorous { get; protected set; } = false;  // ���������� ��
    public bool IsPredator { get; protected set; } = false;     // ������ ��

    public static System.Random Rnd { get; } = new System.Random();   // ��������� ������

    float xPos; // ���������� x ����

    /// <summary>
    /// �������� �������� 
    /// </summary>
    void Awake()
    {
        Animator = GetComponent<Animator>();

        // ������������� ������������� ��������� � ��� ��� ���
        dayOfStarvationMax = Rnd.Next(3, 5);
        ageMax = Rnd.Next(10, 16);

    }

    /// <summary>
    /// ������������ ����������� ���
    /// </summary>
    private void Update()
    {
        // ���� � ����������
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // ������ ��������
        Vector2 movement = new Vector2(moveX, moveY) * 2 * Time.deltaTime;

        // ��������� ������� �������� ����
        fish = ManagerFish.Fish;
        if (fish != null)
        {
            // ����������� ����
            Transform fishTransform = fish.GetComponent<Transform>();
            fishTransform.Translate(movement);

            // ��������� ���������� ������ ����
            Transform[] modelFishesTransform = fish.GetComponentsInChildren<Transform>();
            Transform modelFishTransform = modelFishesTransform[1];

            // ��������� ��������
            float zRot = 0;     // ���������� �������� ����� ������� ������
            float yRot = modelFishTransform.localEulerAngles.y;

            // �������� �� y
            if (moveX < 0) yRot = 0;
            else if (moveX > 0) yRot = 180;

            // �������� �� z
            if (moveY < 0) zRot = 15;
            if (moveY > 0) zRot = -15;

            modelFishTransform.localEulerAngles = new Vector3(0, yRot, zRot);   // ��������� ��������

            // ��������� ������ �� �����
            xPos = fishTransform.position.x;
            float yPos = fishTransform.position.y;
            if (Mathf.Abs(xPos) > 11.7f) fishTransform.position = new Vector2(-xPos, yPos);
        }
    }


    public bool Die()
    {
        age++;

        bool isDie = false;
        xPos = transform.position.x;

        // ������ �� ������
        if (xPos >= 2f && xPos <= 5.5f)
        {
            if (Rnd.Next(0, 2) == 1)
            {
                isDie = true;
            }
        }

        // ������ �� ��������
        if (age >= ageMax)
        {
            isDie = true;
        }

        // ������ �� ������
        if (dayOfStarvation >= dayOfStarvationMax)
        {
            isDie = true;
        }

        return isDie;
    }

    /// <summary>
    /// ������ ���
    /// </summary>
    /// <returns> ���� �� </returns>
    public bool PredatorIsEating()
    {
        bool isEating = false;
        if (Pond.CountCrucians > 0)
        {
            dayOfStarvation = 0;
            isEating = true;
        }
        if (isEating == false) dayOfStarvation++;   // ���� ������ �� ���� �� ��������� ���� ��� ���

        return isEating;
       
    }

    /// <summary>
    /// ���������� ���� ���
    /// </summary>
    /// <returns> ����� �� </returns>
    public bool HerbivorousIsEating()
    {
        bool isEating = false;
        if (Pond.BiomassPlankton > 0)
        {
            Pond.BiomassPlankton--;
            Pond.BiomassFeed--;
            isEating = true;
        }
        else if (Pond.BiomassFeed > 0)
        {
            Pond.BiomassFeed--;
            isEating = true;
        }

        if (isEating == true) dayOfStarvation = 0;  // ���� ���� �� ����� �� ��������� ���� ��� ���
        else dayOfStarvation++;

            return isEating;
    }
}