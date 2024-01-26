using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public enum BulletType//총알타입에 대한 열거형(상수를 기억하기 좋게 그룹화하는 것)
    {
        Main = 0,
        Sub,
        Ult
        
    }
    public  BulletType Btype; //0이면 주총알, 1이면 보조총알 2면 페이쏘는총알



    // 목표 : 총알이 위로 계속 이동하고 싶다.
    // 속성 : speed
    // - 속력
    // 구현순서
    //1 이동할 방향을 구한다.
    //2 이동한다.
    public float Movespeed = 30f; // 이동 속도 : 초당 3만큼 이동하겠다.


    void Start()
    {

    }

    void Update()
    {
        Vector2 dir = Vector2.up;
        transform.position += (Vector3)(dir * Movespeed * Time.deltaTime);
    }
}
