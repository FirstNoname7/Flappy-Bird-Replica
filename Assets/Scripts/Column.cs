using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //����������� ���������� �������, ���������� ��� ������������ �������� ���� � ���������.
                                                    //���������� � ������ other ��������� ������������ ��������� Collider2D
    {
        if (other.GetComponent<Bird>() != null) //���� ����� (����) ������ �� ���� ������� (������ �������), ��:
        {
            GameControl.instance.BirdScored(); //������������ ������� � ������ BirdScored �� ������� � ��������� GameControl. ���������, ��� instance ��������� � ������� GameControl � �������� ������������ ������ ����� ��������

        }
    }
}
