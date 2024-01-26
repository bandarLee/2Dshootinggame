using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public enum BulletType//�Ѿ�Ÿ�Կ� ���� ������(����� ����ϱ� ���� �׷�ȭ�ϴ� ��)
    {
        Main = 0,
        Sub,
        Ult
        
    }
    public  BulletType Btype; //0�̸� ���Ѿ�, 1�̸� �����Ѿ� 2�� ���̽���Ѿ�



    // ��ǥ : �Ѿ��� ���� ��� �̵��ϰ� �ʹ�.
    // �Ӽ� : speed
    // - �ӷ�
    // ��������
    //1 �̵��� ������ ���Ѵ�.
    //2 �̵��Ѵ�.
    public float Movespeed = 30f; // �̵� �ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.


    void Start()
    {

    }

    void Update()
    {
        Vector2 dir = Vector2.up;
        transform.position += (Vector3)(dir * Movespeed * Time.deltaTime);
    }
}
