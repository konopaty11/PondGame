using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucian : Fish
{

    void Start()
    {
        Animator.Play("CrucianAnimation");  // ������ �������� ������

        // ��������� ���� ������ � ����������� � ������ ����
        Weight = Rnd.Next(85, 100) / 100f;  
        Pond.BiomassFish += Weight;

        IsHerbivorous = true;

        ProcMassFeed = 1.2; // ������� ����� ���� �� �����
    }
}