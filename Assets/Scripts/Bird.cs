using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f; //скорость, с которой перс будет взлетать при клике на кнопку
    private Animator anim; //переменная для вызова анимации перса
    private bool isDead = false; //переменная для проверки, умер персонаж или нет. Изначально false, то есть персонаж в начале игры жив
    Rigidbody2D rigidbody2d; //подключаем жёсткое тело, ибо оно у перса используется
    // Start вызывается при старте игры
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //говорим, что жёсткое тело будет использоваться тут
        anim = GetComponent<Animator>(); //говорим,что тут будет использоваться анимация
    }

    // Update вызывается каждый фрейм (кадр)
    void Update()
    {
        if (isDead == false) //если перс не умер
        {
            if (Input.GetMouseButtonDown(0)) //если игрок кликнул левой кнопкой мыши
            {
                rigidbody2d.velocity = Vector2.zero; //скорость перса сбрасывается до нуля. rigidbody2d - меняем жесткое тело
                //Vector2 - направление перса, которое равно zero, то есть нулю
                rigidbody2d.AddForce(new Vector2(0, upForce)); //перс меняет направление движения, появляется new Vector2, который показывает изменение по оси Х и У.
                //по Х = 0, то есть по горизонтали перс не будет двигаться. А по У = upForce, то есть общедоступной переменной, которая указана перед функцией старта (Start), а в ней указано на сколько взлетит перс
                anim.SetTrigger("Flap"); //анимация взлёта. anim - переменная, которая отвечает за анимацию (Animator). SetTrigger - используем тот тип данных, который добавлен в аниматоре (загляни туда, там добавлен параметр Trigger)
                                         //Flap - название анимации, которая будет использоваться (это название снова же есть в параметрах (Parameters))
            }
        }
    }
    void OnCollisionEnter2D() //вызовется при столкновении с Rigidbody или Collider
    {
        rigidbody2d.velocity = Vector2.zero; //сбрасываем скорость в ноль как по горизонтали, так и по вертикали (перс не может двигаться, ведь он умер)
        isDead = true; //перс умирает
        anim.SetTrigger("Die"); //анимация умирания перса.anim - переменная, которая отвечает за анимацию (Animator). SetTrigger - используем тот тип данных, который добавлен в аниматоре (загляни туда, там добавлен параметр Trigger)
                                //Die - название анимации, которая будет использоваться (это название снова же есть в параметрах (Parameters))
        GameControl.instance.BirdDied(); //вызывается функция BirdDied, за которую отвечает instance и которая находится в скрипте с названием GameControl
    }
}
