using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    static public Animator Animator { get; private set; }     // аниматор

    static GameObject fish;     // активная рыба

    // поля рыбы
    public double Weight { get; set; } = 0; // вес
    public double ProcMassFish { get; set; }    // процент массы тела от массы добычи
    public double ProcMassFeed { get; set; }    // процент массы тела от массы корма
    protected int age = 0;  // возвраст
    protected int ageMax;   // максимальный возвраст

    protected int dayOfStarvation = 0;  // день голодовки
    protected int dayOfStarvationMax;   // максимум дней без еды

    public bool IsHerbivorous { get; protected set; } = false;  // травоядный ли
    public bool IsPredator { get; protected set; } = false;     // хищник ли

    public static System.Random Rnd { get; } = new System.Random();   // системный рандом

    float xPos; // координата x рыбы

    /// <summary>
    /// включает анимацию 
    /// </summary>
    void Awake()
    {
        Animator = GetComponent<Animator>();

        // инициализация максимального возвраста и дня без еды
        dayOfStarvationMax = Rnd.Next(3, 5);
        ageMax = Rnd.Next(10, 16);

    }

    /// <summary>
    /// Обеспечивает перемещение рыб
    /// </summary>
    private void Update()
    {
        // ввод с клавиатуры
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // вектор движения
        Vector2 movement = new Vector2(moveX, moveY) * 2 * Time.deltaTime;

        // получение объекта активной рыбы
        fish = ManagerFish.Fish;
        if (fish != null)
        {
            // перемещение рыбы
            Transform fishTransform = fish.GetComponent<Transform>();
            fishTransform.Translate(movement);

            // получение трансформа модели рыбы
            Transform[] modelFishesTransform = fish.GetComponentsInChildren<Transform>();
            Transform modelFishTransform = modelFishesTransform[1];

            // параметры вращения
            float zRot = 0;     // обновление значения после отжатия кнопки
            float yRot = modelFishTransform.localEulerAngles.y;

            // вращение по y
            if (moveX < 0) yRot = 0;
            else if (moveX > 0) yRot = 180;

            // вращение по z
            if (moveY < 0) zRot = 15;
            if (moveY > 0) zRot = -15;

            modelFishTransform.localEulerAngles = new Vector3(0, yRot, zRot);   // установка вращения

            // обработка выхода за сцену
            xPos = fishTransform.position.x;
            float yPos = fishTransform.position.y;
            if (Mathf.Abs(xPos) > 11.7f) fishTransform.position = new Vector2(-xPos, yPos);
        }
    }


    public bool Die()
    {
        age++;

        bool isDie = false;
        xPos = transform.position.x;

        // смерть от рыбака
        if (xPos >= 2f && xPos <= 5.5f)
        {
            if (Rnd.Next(0, 2) == 1)
            {
                isDie = true;
            }
        }

        // смерть от старости
        if (age >= ageMax)
        {
            isDie = true;
        }

        // смерть от голода
        if (dayOfStarvation >= dayOfStarvationMax)
        {
            isDie = true;
        }

        return isDie;
    }

    /// <summary>
    /// хищник ест
    /// </summary>
    /// <returns> поел ли </returns>
    public bool PredatorIsEating()
    {
        bool isEating = false;
        if (Pond.CountCrucians > 0)
        {
            dayOfStarvation = 0;
            isEating = true;
        }
        if (isEating == false) dayOfStarvation++;   // если хищник не поел то прибавить день без еды

        return isEating;
       
    }

    /// <summary>
    /// травоядная рыба ест
    /// </summary>
    /// <returns> поела ли </returns>
    public bool HerbivorousIsEating()
    {
        bool isEating = false;
        if (Pond.BiomassPlankton > 0)
        {
            Pond.BiomassPlankton--;
            Pond.BiomassFeed--;
            isEating = true;
        }
        else if (Pond.BiomassFeed > 0)
        {
            Pond.BiomassFeed--;
            isEating = true;
        }

        if (isEating == true) dayOfStarvation = 0;  // если рыба не поела то прибавить день без еды
        else dayOfStarvation++;

            return isEating;
    }
}