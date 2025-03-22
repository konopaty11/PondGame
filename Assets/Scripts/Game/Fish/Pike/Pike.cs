using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pike : Fish
{
    void Start()
    {
        Animator.Play("PikeAnimation"); // ������ ��������

        // ��������� � ����������� � ������ ����
        Weight = Rnd.Next(200, 300) / 100f;
        Pond.BiomassFish += Weight;

        IsPredator = true;

        ProcMassFish = 0.7; // ������� ����� ������ �� ����������� �����
    }

    /// <summary>
    /// �������������� ������������ �����
    /// ��������� ������ �������� ������
    /// </summary>
    /// <returns> 
    /// ������ �� ���� bool 
    /// 1 - ��������� �� ����
    /// 2 - ����� �� ������
    /// </returns>
    public new (bool, bool) PredatorIsEating()
    {
        bool isEating = false;
        bool isEatCrucian = false;

        if (Pond.CountCrucians > 0)
        {
            dayOfStarvation = 0;
            
            isEating = true;
            isEatCrucian = true;
        }
        else if (Pond.CountPerchs > 0)
        {
            dayOfStarvation = 0;
            
            isEating = true;
        }

        if (isEating == false) dayOfStarvation++;   // ���� ���� �� ����� + ���� ���������

        return (isEating, isEatCrucian);
    }
}
