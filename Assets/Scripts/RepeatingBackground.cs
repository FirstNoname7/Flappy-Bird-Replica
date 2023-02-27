using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    //���� ������ ����� ��� ���������� ���� (���� �� ������� ����� ����� �� 100 ��� � �� �������� ������ ����� � ����� ������)
    //���� 2 ����, ������� ����� - ����� ���� �� ������ ����, ������ �������� � �������� �����, �� ���� ����������� ������� �����. ����� ���� �� ������� ����, �� ������ ���������� ������������ ��� 4 ��� � ��� �� �������������
    private BoxCollider2D groundCollider; //���������� groundCollider, ������� ��������� ������������ ��������� BoxCollider2D � ���� �������
    private float groundHorizontalLength; //���������� ��� ����������� ����� ����, ���� ������ ���������� ������� ������� ���� ��� ���
    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>(); //��������, ��� ��� � ������� ����� ������������ ��������� BoxCollider2D ��������
        groundHorizontalLength = groundCollider.size.x; //��������, ��� ���������� groundHorizontalLength ����� ������� �, ���������� � ������� size � � ����� BoxCollider2D (���� ��� groundCollider=BoxCollider2D)
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength) //���� ������� �� ����������� < (������) �������������� ����� ����� ����, �� ���� ���� ��� ��������� ����������� �����
                                                            //(��� ������ ��������� ����� ����� ���������� ��������������� ��-�� ����, ��� ��������� ������. ������ ������ ������� � ������� 0, ��������������, ���� ����������� ������������ ����� �� ������, �� ��� ����� �������������), ��:
        {
            RepositionBackground(); //���������� ������� � ������ RepositionBackground, �� ���� ��� ������������ ������
        }
    }
    public void RepositionBackground() //� ���� ������� ��������� ��������� ��������� ����
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength*2f,0); //�������� � ����� ����������� ����� ������������ ���������� ���, ������� ���� ��� ������
        //��������� ��� � ���������� � ������ groundOffset. �� �, �� ���� �� �����������, ��� ����� ��������� ����� 1 ��� ������, ������ ��� ���������� ����� ���� �� 2. � ���� �������� �� 1, �� ����� �� ���������� � ��� ��������� �� ����� �����
        //�� � ��� �� ������ �����������, ��������� = 0
        transform.position = (Vector2)transform.position+groundOffset; //��� ��������� ��������� ������� ����. (Vector2)transform.position - ��������, ��� ������� ����� �������� � ������������ � � �, ��� ��� 2� ����
        //� ������� ������������ groundOffset, �� ���� ����������, ����������� ����������� �����������

    }
}
