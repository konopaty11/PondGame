using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Flags
{
    public static bool IsReadySkipDay { get; set; } = false;    // возможно ли пропустить день
    public static bool IsComeBack { get; set; } = false;        // возможно ли вернуться в игру после показа результатов

    public static bool IsSkipEducation { get; set; } = true;    // возможно ли пропустить обучение

    public static bool IsLossFishesDie { get; set; } = false;   // прогрыш - умерли все рыбы
    public static bool IsLossMostBiomassFishes { get; set; } = false;   // проигрыш - достигнута максимальная биомасса рыбы
}
