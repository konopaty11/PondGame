using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateResultsText : MonoBehaviour
{
    // префабы текстов результата
    [SerializeField] GameObject prefabHeaderRes;
    [SerializeField] GameObject prefabMainTextRes;
    // родитель текстов результата
    [SerializeField] GameObject parent;

    // объекты текстов
    GameObject headerRes;
    GameObject mainRes;

    /// <summary>
    /// создание текстов результата
    /// </summary>
    public void CreateResults()
    {
        // заголовок
        headerRes = Instantiate(prefabHeaderRes, transform.position, Quaternion.identity);
        headerRes.transform.SetParent(parent.transform);
        headerRes.transform.localPosition = new Vector2(0, 400);

        // основной текст
        string mainText = $"Всего рыб: {Pond.AllFishes} \n" +
            $"Создано щук: {Pond.CountCreatePikes} \n\t\tВ живых осталось:{Pond.CountPikes} \n" +
            $"Создано окуней: {Pond.CountCreatePerchs} \n\t\tВ живых осталось: {Pond.CountPerchs} \n" +
            $"Создано карасей: {Pond.CountCreateCrucians} \n\t\tВ живых осталось: {Pond.CountCrucians} \n" +
            $"Биомасса рыб: {Pond.BiomassFish}кг \n\t\tМаксимальная: {Pond.MaxBiomassFish}кг \n" +
            $"Биомасса корма: {Pond.BiomassFeed}кг \n\t\tМаксимальная: {Pond.MaxBiomassFeed}кг \n" +
            $"Биомасса планктона: {Pond.BiomassPlankton}кг.";

        // если игрок проиграл активировать флаг
        if (Pond.AllFishes == 12 && (Pond.CountCrucians + Pond.CountPerchs + Pond.CountPikes == 0)) Flags.IsLossFishesDie = true;
        else if (Pond.BiomassFish >= Pond.MaxBiomassFish) Flags.IsLossMostBiomassFishes = true;

        // добавить сообщение о проигрыше
        if (Flags.IsLossMostBiomassFishes) mainText += "\n\nВы програли. Пруд не выдержал стольких рыб...";
        else if (Flags.IsLossFishesDie) mainText += "\n\nВы проиграли. Все рыбы померли...";

        Debug.Log(mainText);    // вывод на консоль

        // основной текст
        mainRes = Instantiate(prefabMainTextRes, transform.position, Quaternion.identity);
        mainRes.transform.SetParent(parent.transform);

        Text text = mainRes.GetComponent<Text>();
        text.text = mainText;

        mainRes.transform.localPosition = new Vector2(0, -100);
    }

    /// <summary>
    /// удаление текстов резальтата
    /// </summary>
    public void DeleteResults()
    {
        Destroy(mainRes);
        Destroy(headerRes);
    }
}
