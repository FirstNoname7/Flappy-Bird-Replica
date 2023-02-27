using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    //этот скрипт отвечает за движение объектов (столбов, фона)
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0); //тут устанавливаем движение фона и скорость
        //rigidbody2d.velocity - используем Rigidbody2D, ибо оно добавлено в инспекторе к фону. new Vector2 - новое направление движения
        //по Х - скорость указана в переменной scrollSpeed из скрипта GameControl. По у фон перемещаться не будет
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.gameOver==true) //если переменная gameOver из скрипта с именем GameControl равна истине, то игра заканчивается, и:
        {
            rigidbody2d.velocity = Vector2.zero; //движение фона останавливается, потому что направления движения по х и у равны zero, то есть нулю
        }
    }
}
