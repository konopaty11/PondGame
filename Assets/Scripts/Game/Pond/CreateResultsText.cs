using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateResultsText : MonoBehaviour
{
    // ������� ������� ����������
    [SerializeField] GameObject prefabHeaderRes;
    [SerializeField] GameObject prefabMainTextRes;
    // �������� ������� ����������
    [SerializeField] GameObject parent;

    // ������� �������
    GameObject headerRes;
    GameObject mainRes;

    /// <summary>
    /// �������� ������� ����������
    /// </summary>
    public void CreateResults()
    {
        // ���������
        headerRes = Instantiate(prefabHeaderRes, transform.position, Quaternion.identity);
        headerRes.transform.SetParent(parent.transform);
        headerRes.transform.localPosition = new Vector2(0, 400);

        // �������� �����
        string mainText = $"����� ���: {Pond.AllFishes} \n" +
            $"������� ���: {Pond.CountCreatePikes} \n\t\t� ����� ��������:{Pond.CountPikes} \n" +
            $"������� ������: {Pond.CountCreatePerchs} \n\t\t� ����� ��������: {Pond.CountPerchs} \n" +
            $"������� �������: {Pond.CountCreateCrucians} \n\t\t� ����� ��������: {Pond.CountCrucians} \n" +
            $"�������� ���: {Pond.BiomassFish}�� \n\t\t������������: {Pond.MaxBiomassFish}�� \n" +
            $"�������� �����: {Pond.BiomassFeed}�� \n\t\t������������: {Pond.MaxBiomassFeed}�� \n" +
            $"�������� ���������: {Pond.BiomassPlankton}��.";

        // ���� ����� �������� ������������ ����
        if (Pond.AllFishes == 12 && (Pond.CountCrucians + Pond.CountPerchs + Pond.CountPikes == 0)) Flags.IsLossFishesDie = true;
        else if (Pond.BiomassFish >= Pond.MaxBiomassFish) Flags.IsLossMostBiomassFishes = true;

        // �������� ��������� � ���������
        if (Flags.IsLossMostBiomassFishes) mainText += "\n\n�� ��������. ���� �� �������� �������� ���...";
        else if (Flags.IsLossFishesDie) mainText += "\n\n�� ���������. ��� ���� �������...";

        Debug.Log(mainText);    // ����� �� �������

        // �������� �����
        mainRes = Instantiate(prefabMainTextRes, transform.position, Quaternion.identity);
        mainRes.transform.SetParent(parent.transform);

        Text text = mainRes.GetComponent<Text>();
        text.text = mainText;

        mainRes.transform.localPosition = new Vector2(0, -100);
    }

    /// <summary>
    /// �������� ������� ����������
    /// </summary>
    public void DeleteResults()
    {
        Destroy(mainRes);
        Destroy(headerRes);
    }
}
