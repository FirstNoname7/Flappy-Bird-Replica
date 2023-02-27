using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    //этот скрипт нужен для повторения фона (чтоб не спамить одним фоном по 100 раз и не занимать лишнее место в компе игрока)
    //есть 2 фона, принцип такой - когда перс на втором фоне, первый исчезает и ставится вперёд, то есть ставновится третьим фоном. Когда перс на третьем фоне, то второй быстренько перемещается как 4 фон и так до бесконечности
    private BoxCollider2D groundCollider; //переменная groundCollider, которая позволяет использовать компонент BoxCollider2D в этом скрипте
    private float groundHorizontalLength; //переменная для определения длины фона, чтоб второй поместился заместо первого фона без шва
    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>(); //указываю, что тут в скрипте можно использовать компонент BoxCollider2D объектов
        groundHorizontalLength = groundCollider.size.x; //указываю, что переменная groundHorizontalLength равна размеру х, указанному в строчке size и в блоке BoxCollider2D (если что groundCollider=BoxCollider2D)
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength) //если позиция по горизонтали < (меньше) отрицательного числа длины фона, то есть один фон полностью прокрутился влево
                                                            //(при полной прокрутке влево числа становятся отрицательнеыми из-за того, что смещается камера. Камера всегда смотрит в позицию 0, соответственно, если переместить пространство влево от камеры, то оно будет отрицательным), то:
        {
            RepositionBackground(); //вызывается функция с именем RepositionBackground, то есть фон перемещается вправо
        }
    }
    public void RepositionBackground() //в этой функции прописано изменение положения фона
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength*2f,0); //указываю в каком направлении будет перемещаться предыдущий фон, который перс уже прошёл
        //запихиваю это в переменную с именем groundOffset. По х, то есть по горизонтали, фон будет смещаться ровно 1 раз вправо, потому что умножается длина фона на 2. А если умножить на 1, то число не поменяется и фон останется на одном месте
        //по у фон не меняет направления, стабильно = 0
        transform.position = (Vector2)transform.position+groundOffset; //тут применяем изменение позиции фона. (Vector2)transform.position - Указываю, что позиция будет меняться в направлениях х и у, ибо это 2Д игра
        //к позиции прибавляется groundOffset, то есть переменная, указывающая направление перемещения

    }
}
