using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f; //��������, � ������� ���� ����� �������� ��� ����� �� ������
    private Animator anim; //���������� ��� ������ �������� �����
    private bool isDead = false; //���������� ��� ��������, ���� �������� ��� ���. ���������� false, �� ���� �������� � ������ ���� ���
    Rigidbody2D rigidbody2d; //���������� ������ ����, ��� ��� � ����� ������������
    // Start ���������� ��� ������ ����
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //�������, ��� ������ ���� ����� �������������� ���
        anim = GetComponent<Animator>(); //�������,��� ��� ����� �������������� ��������
    }

    // Update ���������� ������ ����� (����)
    void Update()
    {
        if (isDead == false) //���� ���� �� ����
        {
            if (Input.GetMouseButtonDown(0)) //���� ����� ������� ����� ������� ����
            {
                rigidbody2d.velocity = Vector2.zero; //�������� ����� ������������ �� ����. rigidbody2d - ������ ������� ����
                //Vector2 - ����������� �����, ������� ����� zero, �� ���� ����
                rigidbody2d.AddForce(new Vector2(0, upForce)); //���� ������ ����������� ��������, ���������� new Vector2, ������� ���������� ��������� �� ��� � � �.
                //�� � = 0, �� ���� �� ����������� ���� �� ����� ���������. � �� � = upForce, �� ���� ������������� ����������, ������� ������� ����� �������� ������ (Start), � � ��� ������� �� ������� ������� ����
                anim.SetTrigger("Flap"); //�������� �����. anim - ����������, ������� �������� �� �������� (Animator). SetTrigger - ���������� ��� ��� ������, ������� �������� � ��������� (������� ����, ��� �������� �������� Trigger)
                                         //Flap - �������� ��������, ������� ����� �������������� (��� �������� ����� �� ���� � ���������� (Parameters))
            }
        }
    }
    void OnCollisionEnter2D() //��������� ��� ������������ � Rigidbody ��� Collider
    {
        rigidbody2d.velocity = Vector2.zero; //���������� �������� � ���� ��� �� �����������, ��� � �� ��������� (���� �� ����� ���������, ���� �� ����)
        isDead = true; //���� �������
        anim.SetTrigger("Die"); //�������� �������� �����.anim - ����������, ������� �������� �� �������� (Animator). SetTrigger - ���������� ��� ��� ������, ������� �������� � ��������� (������� ����, ��� �������� �������� Trigger)
                                //Die - �������� ��������, ������� ����� �������������� (��� �������� ����� �� ���� � ���������� (Parameters))
        GameControl.instance.BirdDied(); //���������� ������� BirdDied, �� ������� �������� instance � ������� ��������� � ������� � ��������� GameControl
    }
}
