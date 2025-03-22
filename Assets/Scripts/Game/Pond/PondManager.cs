using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PondManager : MonoBehaviour
{
    // префабы водорослей
    [SerializeField] GameObject prefabSeaweedRed;
    [SerializeField] GameObject prefabSeaweedGreen;
    // родитель водорослей
    [SerializeField] GameObject parentSeaweed;

    // массивы рыб каждого вида
    Perch[] perchs = new Perch[ManagerFish.Fishes.Length];
    Pike[] pikes = new Pike[ManagerFish.Fishes.Length];
    Crucian[] crucians = new Crucian[ManagerFish.Fishes.Length];

    static System.Random rnd = new System.Random(); // системный рандом

    // количество дней выбранных пользователем
    static int countOfDays; 
    public static int CountOfDays { get => countOfDays; set { if (0 <= value && value <= 99) countOfDays = value; } }

    CreateResultsText canvasRes;            // скрипт создания результатов
    UninteractableUI canvasUI;              // скрипт потухания UI на канвасе
    UninvisibleGameObjects[] prefabs;       // скрипт потухания объектов на сцене

    GameObject[] fishes;

    /// <summary>
    /// первичное  создание водорослей и инициализация полей объектами классов
    /// </summary>
    void Start()
    {
        Pond.CreateSeaweed(prefabSeaweedRed, prefabSeaweedGreen, parentSeaweed,  1);
        
        canvasUI = FindObjectOfType<UninteractableUI>();
        canvasRes = FindObjectOfType<CreateResultsText>();
        prefabs = FindObjectsByType<UninvisibleGameObjects>(FindObjectsSortMode.InstanceID);
    }


    /// <summary>
    /// пропуск дня по нажатию на +, с проверкой на возможность пропуска
    /// </summary>
    private void Update()
    {
        // если нажат + сделать объекты неинтеративными и показать результаты
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Flags.IsReadySkipDay)
        {
            Flags.IsReadySkipDay = false;
            Flags.IsComeBack = true;

            SkipDay(prefabSeaweedRed, prefabSeaweedGreen, 1);
            Uninteractable();
            canvasRes.CreateResults();
        }
        // при нажании на пробел убрать результаты и вернуть интерактивность объектам
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
    /// пропустить выбранное кол-во дней
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
    /// пропуск дней
    /// </summary>
    /// <param name="prefabSeaweedRed"> префаб красной водоросли </param>
    /// <param name="prefabSeaweedGreen"> префаб зелёной водоросли </param>
    /// <param name="days"> количество дней, которые необходимо пропустить </param>
    public void SkipDay(GameObject prefabSeaweedRed, GameObject prefabSeaweedGreen, int days)
    {
        for (int i = 0; i < days; i++)  // цикл всего дня
        {
            Pond.CreateSeaweed(prefabSeaweedRed, prefabSeaweedGreen, parentSeaweed, 1);    // создание водорослей

            // создание экземпляра массива Fishes и заполнение массивов каждого вида рыб
            fishes = ManagerFish.Fishes;
            for (int j = 0; j < fishes.Length; j++)
                if (fishes[j] != null)
                {
                    if (fishes[j].CompareTag("Pike")) pikes[j] = fishes[j].GetComponent<Pike>();
                    else if (fishes[j].CompareTag("Perch")) perchs[j] = fishes[j].GetComponent<Perch>();
                    else if (fishes[j].CompareTag("Crucian")) crucians[j] = fishes[j].GetComponent<Crucian>();
                }


            // щука ест
            foreach (Pike pike in pikes)
                if (pike != null)
                {
                    var res = pike.PredatorIsEating();
                    // если был съеден карась, то удалить его и добавить щуке его вес
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
                                Debug.Log("щука съела карася");
                                break;
                            }
                    }   // скобку не убирать - else считает себя частью if внутри for сверху

                    // если был съеден окунь, то удалить его и прибавить его вес к щуке
                    else if (res.Item1 && !res.Item2 && pike.IsPredator)
                        for (int k = 0; k < perchs.Length; k++)
                            if (perchs[k] != null && perchs[k].Weight / pike.Weight <= pike.ProcMassFish)
                            {
                                pike.Weight += perchs[k].Weight;
                                Pond.CountPerchs--;

                                Destroy(fishes[k]);
                                fishes[k] = null;
                                perchs[k] = null;
                                Debug.Log("щука съела окуня");
                                break;
                            }
                }

            // окунь ест
            foreach (Perch perch in perchs)
                if (perch != null)
                {
                    bool isFishEating = perch.PredatorIsEating();
                    // если окунь съел карася, то удалить карася и добавить его вес окуню
                    if (isFishEating && perch.IsPredator)
                        for (int k = 0; k < crucians.Length; k++)
                            if (crucians[k] != null && crucians[k].Weight / perch.Weight <= perch.ProcMassFish)
                            {
                                perch.Weight += crucians[k].Weight;
                                Pond.CountCrucians--;

                                Destroy(fishes[k]);
                                crucians[k] = null;
                                fishes[k] = null;
                                Debug.Log("окунь съел карася");
                                break;
                            }

                    // если окунь съел водоросль то удалить её и прибавить окуню 1кг
                    if (!isFishEating && perch.IsHerbivorous && perch.HerbivorousIsEating())
                        for (int k = 0; k < 15; k++)
                            if (Pond.Seaweed[k] != null && 1 / perch.Weight <= perch.ProcMassFeed)
                            {
                                perch.Weight += 1;
                                Pond.BiomassFish += 1;

                                Destroy(Pond.Seaweed[k]);
                                Pond.Seaweed[k] = null;
                                Debug.Log("окунь съел водоросль");
                                break;
                            }
                }

            // карась ест водоросль и тяжелеет на 1 кг
            foreach (Crucian crucian in crucians)
                if (crucian != null && crucian.IsHerbivorous && crucian.HerbivorousIsEating()) 
                        for (int k = 0; k < 15; k++)
                            if (Pond.Seaweed[k] != null && 1 / crucian.Weight <= crucian.ProcMassFeed)
                            {
                                crucian.Weight += 1;
                                Pond.BiomassFish += 1;

                                Destroy(Pond.Seaweed[k]);
                                Pond.Seaweed[k] = null;
                                Debug.Log("карась съел водоросль");
                                break;
                            }

            // щука умирает
            for (int k = 0; k < pikes.Length; k++)
                if (pikes[k] != null && pikes[k].Die())
                {
                    Pond.BiomassFish -= pikes[k].Weight;
                    Pond.CountPikes--;

                    Destroy(fishes[k]);
                    pikes[k] = null;
                    fishes[k] = null;
                    Debug.Log("щука умерла");
                }

            // окунь умирает
            for (int k = 0; k < perchs.Length; k++)
                if (perchs[k] != null && perchs[k].Die())
                {
                    Pond.BiomassFish -= perchs[k].Weight;
                    Pond.CountPerchs--;

                    Destroy(fishes[k]);
                    fishes[k] = null;
                    perchs[k] = null;
                    Debug.Log("окунь умер");
                }

            // карась умирает
            for (int k = 0; k < crucians.Length; k++)
                if (crucians[k] != null && crucians[k].Die())
                {
                    Pond.BiomassFish -= crucians[k].Weight;
                    Pond.CountCrucians--;

                    Destroy(fishes[k]);
                    fishes[k] = null;
                    crucians[k] = null;
                    Debug.Log("карась умер");
                }
        }
    }


    /// <summary>
    /// реализует затухание объектов
    /// </summary>
    void Uninteractable()
    {
        canvasUI.Uninteractable();    

        foreach (UninvisibleGameObjects prefab in prefabs)
            prefab.Uninvisible();
    }

    /// <summary>
    /// реализует появление объектов
    /// </summary>
    void Interactable()
    {
        canvasUI.Interactable();

        foreach (UninvisibleGameObjects prefab in prefabs)
            prefab.Invisible();
    }

}