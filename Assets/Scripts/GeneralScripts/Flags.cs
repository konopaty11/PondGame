using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Flags
{
    public static bool IsReadySkipDay { get; set; } = false;    // �������� �� ���������� ����
    public static bool IsComeBack { get; set; } = false;        // �������� �� ��������� � ���� ����� ������ �����������

    public static bool IsSkipEducation { get; set; } = true;    // �������� �� ���������� ��������

    public static bool IsLossFishesDie { get; set; } = false;   // ������� - ������ ��� ����
    public static bool IsLossMostBiomassFishes { get; set; } = false;   // �������� - ���������� ������������ �������� ����
}
