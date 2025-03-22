using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pike : Fish
{
    void Start()
    {
        Animator.Play("PikeAnimation"); // запуск анимации

        // установка и прибавление к общему веса
        Weight = Rnd.Next(200, 300) / 100f;
        Pond.BiomassFish += Weight;

        IsPredator = true;

        ProcMassFish = 0.7; // процент массы добычи от собственной массы
    }

    /// <summary>
    /// переопределяет родительский класс
    /// добавляет логику поедания окуней
    /// </summary>
    /// <returns> 
    /// кортеж из двух bool 
    /// 1 - пообедала ли щука
    /// 2 - съела ли карася
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

        if (isEating == false) dayOfStarvation++;   // если рыба не поела + день голодовки

        return (isEating, isEatCrucian);
    }
}
