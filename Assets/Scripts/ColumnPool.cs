using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int ColumnPoolSize = 5; //тут указано кол-во элементов для массива с именем columns
    public GameObject columnPrefab; //переменная для добавления в инспекторе префаба колонны
    public float spawnRate = 4f; //расстояние между спавном 2-ух объектов (колонн), чтоб они не спавнились друг на друге. Выражается в секундах. То есть 1 раз в 4 секунды спавнится колонна.
    public float columnMin = -1f; //минимальное положение новой колонны, которая заспавнилась(по вертикали)
    public float columnMax = 3.5f; //максимальное положение новой колонны, которая заспавнилась(по вертикали)

    private GameObject[] columns; //тут массив с колоннами, которые должны спавниться
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f); //тут указывается позиция спавна колонн. у вектора отрицательные числа, чтобы спавн был за пределами игры
    private float timeSinceLastSpawned; //таймер для спавна колонн (чтобы они спавнились через определённые промежутки времени)
    private float spawnXPosition = 10f; //позиция новой колонны, которая спавнится. То есть на 10 единиц правее камеры. Это надо, чтоб колонна случайно не заспавнилась прям перед носом у игрока. Она спавнится за пределами камеры, то есть процесс спавна не виден.
    private int currentColumn = 0; //значение текущего столбца (колонны), через которую перс летит. То есть потом это значение будет увеличиваться до 5, потом снова сбросится до нуля и т.д., пойдёт бесконечный цикл 
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[ColumnPoolSize]; //тут в переменной columns хранится массив GameObject[], состоящий из элементов ColumnPoolSize
        for (int i = 0; i < ColumnPoolSize; i++) //цикл. Я написала for, кликнула 2 раза на Tаb и появилось всё остальное, заменила только length на ColumnPoolSize
                                                 //то есть если у переменной i меньше элементов (колонн), чем указано в переменной ColumnPoolSize, тогда добавляем недостающие элементы (i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity); //создаём новую колонну. Это GameObject. Создаётся при помощи Instantiate:
            //columnPrefab - то есть создаётся новый префаб колонны с позицией objectPoolPosition и вращением Quaternion.identity (то есть нулевым)
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime; //таймер для спавна колонн
        if (GameControl.instance.gameOver==false && timeSinceLastSpawned>=spawnRate) //если игра не окончена (gameOver==false) и (&&) таймер для спавна колонн (timeSinceLastSpawned) больше значения в расстоянии между 2-умя колоннами (spawnRate),то есть прошло 4 секунды, то:
        {
            timeSinceLastSpawned = 0; //обнуляем таймер
            float spawnYPosition = Random.Range(columnMin, columnMax); //спавним новую колонну с рандомной позицией по вертикали (по у) в пределах от columnMin до columnMax (то есть от -1 до 3.5) и сохраняем её в переменной с именем spawnYPosition
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition); //полная позиция новой колонны, которая спавнится (по горизонтали = spawnXPosition, то есть 10, по вертикали =spawnYPosition, то есть рандомное место от -1 до 3.5)
            currentColumn++; //то есть когда заспавнилась текущая колонна, то автоматически спавнится вторая, чтоб игра была непрерывной
            if (currentColumn >= ColumnPoolSize) //если значение текущего столбца (колонны) выходит за пределы максимального кол-ва элементов массива (ColumnPoolSize), тогда:
            {
                currentColumn = 0; //обнуляем значение текущей колонны. Потом цикл начнётся заново
            }
        }
    }
}
