using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PondManager : MonoBehaviour
{
    // ������� ����������
    [SerializeField] GameObject prefabSeaweedRed;
    [SerializeField] GameObject prefabSeaweedGreen;
    // �������� ����������
    [SerializeField] GameObject parentSeaweed;

    // ������� ��� ������� ����
    Perch[] perchs = new Perch[ManagerFish.Fishes.Length];
    Pike[] pikes = new Pike[ManagerFish.Fishes.Length];
    Crucian[] crucians = new Crucian[ManagerFish.Fishes.Length];

    static System.Random rnd = new System.Random(); // ��������� ������

    // ���������� ���� ��������� �������������
    static int countOfDays; 
    public static int CountOfDays { get => countOfDays; set { if (0 <= value && value <= 99) countOfDays = value; } }

    CreateResultsText canvasRes;            // ������ �������� �����������
    UninteractableUI canvasUI;              // ������ ��������� UI �� �������
    UninvisibleGameObjects[] prefabs;       // ������ ��������� �������� �� �����

    GameObject[] fishes;

    /// <summary>
    /// ���������  �������� ���������� � ������������� ����� ��������� �������
    /// </summary>
    void Start()
    {
        Pond.CreateSeaweed(prefabSeaweedRed, prefabSeaweedGreen, parentSeaweed,  1);
        
        canvasUI = FindObjectOfType<UninteractableUI>();
        canvasRes = FindObjectOfType<CreateResultsText>();
        prefabs = FindObjectsByType<UninvisibleGameObjects>(FindObjectsSortMode.InstanceID);
    }


    /// <summary>
    /// ������� ��� �� ������� �� +, � ��������� �� ����������� ��������
    /// </summary>
    private void Update()
    {
        // ���� ����� + ������� ������� ��������������� � �������� ����������
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Flags.IsReadySkipDay)
        {
            Flags.IsReadySkipDay = false;
            Flags.IsComeBack = true;

            SkipDay(prefabSeaweedRed, prefabSeaweedGreen, 1);
            Uninteractable();
            canvasRes.CreateResults();
        }
        // ��� ������� �� ������ ������ ���������� � ������� ��������������� ��������
        else if (Input.GetKeyDown(KeyCode.Space) && Flags.IsComeBack)
        {
            Flags.IsComeBack = false;
            Flags.IsReadySkipDay = true;

            if (Flags.IsLossMostBiomassFishes || Flags.IsLossFishesDie) SceneManager.LoadScene("MainMenu");
            else
            {
                canvasRes.DeleteResults();
                Interactable();

            }
        }
    }

    /// <summary>
    /// ���������� ��������� ���-�� ����
    /// </summary>
    public void SkipSomeDays()
    {
        Flags.IsReadySkipDay = false;
        Flags.IsComeBack = true;

        SkipDay(prefabSeaweedRed, prefabSeaweedGreen, Convert.ToInt32(CreateTextChangeDay.InputText.text));
        Uninteractable();
        canvasRes.CreateResults();
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    /// <param name="prefabSeaweedRed"> ������ ������� ��������� </param>
    /// <param name="prefabSeaweedGreen"> ������ ������ ��������� </param>
    /// <param name="days"> ���������� ����, ������� ���������� ���������� </param>
    public void SkipDay(GameObject prefabSeaweedRed, GameObject prefabSeaweedGreen, int days)
    {
        for (int i = 0; i < days; i++)  // ���� ����� ���
        {
            Pond.CreateSeaweed(prefabSeaweedRed, prefabSeaweedGreen, parentSeaweed, 1);    // �������� ����������

            // �������� ���������� ������� Fishes � ���������� �������� ������� ���� ���
            fishes = ManagerFish.Fishes;
            for (int j = 0; j < fishes.Length; j++)
                if (fishes[j] != null)
                {
                    if (fishes[j].CompareTag("Pike")) pikes[j] = fishes[j].GetComponent<Pike>();
                    else if (fishes[j].CompareTag("Perch")) perchs[j] = fishes[j].GetComponent<Perch>();
                    else if (fishes[j].CompareTag("Crucian")) crucians[j] = fishes[j].GetComponent<Crucian>();
                }


            // ���� ���
            foreach (Pike pike in pikes)
                if (pike != null)
                {
                    var res = pike.PredatorIsEating();
                    // ���� ��� ������ ������, �� ������� ��� � �������� ���� ��� ���
                    if (res.Item1 && res.Item2 && pike.IsPredator)
                    {
                        for (int k = 0; k < crucians.Length; k++)
                            if (crucians[k] != null && crucians[k].Weight / pike.Weight <= pike.ProcMassFish)
                            {
                                pike.Weight += crucians[k].Weight;
                                Pond.CountCrucians--;

                                Destroy(fishes[k]);
                                fishes[k] = null;
                                crucians[k] = null;
                                Debug.Log("���� ����� ������");
                                break;
                            }
                    }   // ������ �� ������� - else ������� ���� ������ if ������ for ������

                    // ���� ��� ������ �����, �� ������� ��� � ��������� ��� ��� � ����
                    else if (res.Item1 && !res.Item2 && pike.IsPredator)
                        for (int k = 0; k < perchs.Length; k++)
                            if (perchs[k] != null && perchs[k].Weight / pike.Weight <= pike.ProcMassFish)
                            {
                                pike.Weight += perchs[k].Weight;
                                Pond.CountPerchs--;

                                Destroy(fishes[k]);
                                fishes[k] = null;
                                perchs[k] = null;
                                Debug.Log("���� ����� �����");
                                break;
                            }
                }

            // ����� ���
            foreach (Perch perch in perchs)
                if (perch != null)
                {
                    bool isFishEating = perch.PredatorIsEating();
                    // ���� ����� ���� ������, �� ������� ������ � �������� ��� ��� �����
                    if (isFishEating && perch.IsPredator)
                        for (int k = 0; k < crucians.Length; k++)
                            if (crucians[k] != null && crucians[k].Weight / perch.Weight <= perch.ProcMassFish)
                            {
                                perch.Weight += crucians[k].Weight;
                                Pond.CountCrucians--;

                                Destroy(fishes[k]);
                                crucians[k] = null;
                                fishes[k] = null;
                                Debug.Log("����� ���� ������");
                                break;
                            }

                    // ���� ����� ���� ��������� �� ������� � � ��������� ����� 1��
                    if (!isFishEating && perch.IsHerbivorous && perch.HerbivorousIsEating())
                        for (int k = 0; k < 15; k++)
                            if (Pond.Seaweed[k] != null && 1 / perch.Weight <= perch.ProcMassFeed)
                            {
                                perch.Weight += 1;
                                Pond.BiomassFish += 1;

                                Destroy(Pond.Seaweed[k]);
                                Pond.Seaweed[k] = null;
                                Debug.Log("����� ���� ���������");
                                break;
                            }
                }

            // ������ ��� ��������� � �������� �� 1 ��
            foreach (Crucian crucian in crucians)
                if (crucian != null && crucian.IsHerbivorous && crucian.HerbivorousIsEating()) 
                        for (int k = 0; k < 15; k++)
                            if (Pond.Seaweed[k] != null && 1 / crucian.Weight <= crucian.ProcMassFeed)
                            {
                                crucian.Weight += 1;
                                Pond.BiomassFish += 1;

                                Destroy(Pond.Seaweed[k]);
                                Pond.Seaweed[k] = null;
                                Debug.Log("������ ���� ���������");
                                break;
                            }

            // ���� �������
            for (int k = 0; k < pikes.Length; k++)
                if (pikes[k] != null && pikes[k].Die())
                {
                    Pond.BiomassFish -= pikes[k].Weight;
                    Pond.CountPikes--;

                    Destroy(fishes[k]);
                    pikes[k] = null;
                    fishes[k] = null;
                    Debug.Log("���� ������");
                }

            // ����� �������
            for (int k = 0; k < perchs.Length; k++)
                if (perchs[k] != null && perchs[k].Die())
                {
                    Pond.BiomassFish -= perchs[k].Weight;
                    Pond.CountPerchs--;

                    Destroy(fishes[k]);
                    fishes[k] = null;
                    perchs[k] = null;
                    Debug.Log("����� ����");
                }

            // ������ �������
            for (int k = 0; k < crucians.Length; k++)
                if (crucians[k] != null && crucians[k].Die())
                {
                    Pond.BiomassFish -= crucians[k].Weight;
                    Pond.CountCrucians--;

                    Destroy(fishes[k]);
                    fishes[k] = null;
                    crucians[k] = null;
                    Debug.Log("������ ����");
                }
        }
    }


    /// <summary>
    /// ��������� ��������� ��������
    /// </summary>
    void Uninteractable()
    {
        canvasUI.Uninteractable();    

        foreach (UninvisibleGameObjects prefab in prefabs)
            prefab.Uninvisible();
    }

    /// <summary>
    /// ��������� ��������� ��������
    /// </summary>
    void Interactable()
    {
        canvasUI.Interactable();

        foreach (UninvisibleGameObjects prefab in prefabs)
            prefab.Invisible();
    }

}