using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class ResetSettings : MonoBehaviour
{
    System.Random rnd = new System.Random();

    /// <summary>
    /// обнуление параметров при запуске сцены
    /// </summary>
    void Awake()
    {
        Flags.IsSkipEducation = true;
        Flags.IsReadySkipDay = false;
        Flags.IsLossFishesDie = false;
        Flags.IsLossMostBiomassFishes = false;
        Flags.IsComeBack = false;

        Pond.MaxBiomassFish = rnd.Next(160, 200) / 10f;
        Pond.BiomassFish = 0;

        Pond.MaxBiomassFeed = rnd.Next(10, 15);
        Pond.BiomassFeed = 0;

        Pond.BiomassPlankton = 0;

        Pond.AllFishes = 0;

        Pond.CountPerchs = 0;
        Pond.CountCreatePerchs = 0;

        Pond.CountPikes = 0;
        Pond.CountCreatePikes = 0;

        Pond.CountCrucians = 0;
        Pond.CountCreateCrucians = 0;
    
    }
}
