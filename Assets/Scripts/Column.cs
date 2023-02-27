using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //стандартная юнитовская функция, вызывается при столкновении жесткого тела с триггером.
                                                    //переменная с именем other позволяет использовать компонент Collider2D
    {
        if (other.GetComponent<Bird>() != null) //если птица (Руби) попала на этот триггер (прошла колонну), то:
        {
            GameControl.instance.BirdScored(); //используется функция с именем BirdScored из скрипта с названием GameControl. Напоминаю, что instance находится в скрипте GameControl и помогает использовать оттуда любые элементы

        }
    }
}
