using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perch : Fish
{    
    void Start()
    {
        Animator.Play("PerchAnimation");    // запуск анимации

        // присваивание прибавление к общему весу
        Weight = Rnd.Next(80, 90) / 100f;
        Pond.BiomassFish += Weight;

        IsHerbivorous = true;
        IsPredator = true;

        // проценты массы добычи и массы корма от собственной массы
        ProcMassFeed = 1.3; 
        ProcMassFish = 1.2;
    }
}
