using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int ColumnPoolSize = 5; //��� ������� ���-�� ��������� ��� ������� � ������ columns
    public GameObject columnPrefab; //���������� ��� ���������� � ���������� ������� �������
    public float spawnRate = 4f; //���������� ����� ������� 2-�� �������� (������), ���� ��� �� ���������� ���� �� �����. ���������� � ��������. �� ���� 1 ��� � 4 ������� ��������� �������.
    public float columnMin = -1f; //����������� ��������� ����� �������, ������� ������������(�� ���������)
    public float columnMax = 3.5f; //������������ ��������� ����� �������, ������� ������������(�� ���������)

    private GameObject[] columns; //��� ������ � ���������, ������� ������ ����������
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f); //��� ����������� ������� ������ ������. � ������� ������������� �����, ����� ����� ��� �� ��������� ����
    private float timeSinceLastSpawned; //������ ��� ������ ������ (����� ��� ���������� ����� ����������� ���������� �������)
    private float spawnXPosition = 10f; //������� ����� �������, ������� ���������. �� ���� �� 10 ������ ������ ������. ��� ����, ���� ������� �������� �� ������������ ���� ����� ����� � ������. ��� ��������� �� ��������� ������, �� ���� ������� ������ �� �����.
    private int currentColumn = 0; //�������� �������� ������� (�������), ����� ������� ���� �����. �� ���� ����� ��� �������� ����� ������������� �� 5, ����� ����� ��������� �� ���� � �.�., ����� ����������� ���� 
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[ColumnPoolSize]; //��� � ���������� columns �������� ������ GameObject[], ��������� �� ��������� ColumnPoolSize
        for (int i = 0; i < ColumnPoolSize; i++) //����. � �������� for, �������� 2 ���� �� T�b � ��������� �� ���������, �������� ������ length �� ColumnPoolSize
                                                 //�� ���� ���� � ���������� i ������ ��������� (������), ��� ������� � ���������� ColumnPoolSize, ����� ��������� ����������� �������� (i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity); //������ ����� �������. ��� GameObject. �������� ��� ������ Instantiate:
            //columnPrefab - �� ���� �������� ����� ������ ������� � �������� objectPoolPosition � ��������� Quaternion.identity (�� ���� �������)
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime; //������ ��� ������ ������
        if (GameControl.instance.gameOver==false && timeSinceLastSpawned>=spawnRate) //���� ���� �� �������� (gameOver==false) � (&&) ������ ��� ������ ������ (timeSinceLastSpawned) ������ �������� � ���������� ����� 2-��� ��������� (spawnRate),�� ���� ������ 4 �������, ��:
        {
            timeSinceLastSpawned = 0; //�������� ������
            float spawnYPosition = Random.Range(columnMin, columnMax); //������� ����� ������� � ��������� �������� �� ��������� (�� �) � �������� �� columnMin �� columnMax (�� ���� �� -1 �� 3.5) � ��������� � � ���������� � ������ spawnYPosition
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition); //������ ������� ����� �������, ������� ��������� (�� ����������� = spawnXPosition, �� ���� 10, �� ��������� =spawnYPosition, �� ���� ��������� ����� �� -1 �� 3.5)
            currentColumn++; //�� ���� ����� ������������ ������� �������, �� ������������� ��������� ������, ���� ���� ���� �����������
            if (currentColumn >= ColumnPoolSize) //���� �������� �������� ������� (�������) ������� �� ������� ������������� ���-�� ��������� ������� (ColumnPoolSize), �����:
            {
                currentColumn = 0; //�������� �������� ������� �������. ����� ���� ������� ������
            }
        }
    }
}
