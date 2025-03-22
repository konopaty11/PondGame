using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perch : Fish
{    
    void Start()
    {
        Animator.Play("PerchAnimation");    // ������ ��������

        // ������������ ����������� � ������ ����
        Weight = Rnd.Next(80, 90) / 100f;
        Pond.BiomassFish += Weight;

        IsHerbivorous = true;
        IsPredator = true;

        // �������� ����� ������ � ����� ����� �� ����������� �����
        ProcMassFeed = 1.3; 
        ProcMassFish = 1.2;
    }
}
