using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float Movespeed = 3f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public Animator MyAnimatior;
    void Update()
    {

        Move();

    }
    private void Awake()
    {
        MyAnimatior = this.GetComponent<Animator>();
    }
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal"); // -1.0f ~0f ~ +1.0f 수평값
        float v = Input.GetAxisRaw("Vertical"); // -1.0f ~0f ~ +1.0f 수직값

        MyAnimatior.SetInteger("h", (int)h);

        //Vector2 dir = Vector2.right * h + Vector2.up * v;
        Vector2 dir = new Vector2(h, v);
        dir = dir.normalized;

        Vector2 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
        Vector2 MaxPosition = new Vector2(2.4f, 0f);
        Vector2 MinPosition = new Vector2(-2.4f, -4.5f);
        Vector2 MinXUpdatePosition = new Vector2(2.0f, newPosition.y);
        Vector2 MaxXUpdatePosition = new Vector2(-2.0f, newPosition.y);
        Vector2 MinYUpdatePosition = new Vector2(newPosition.x, -4.5f);
        Vector2 MaxYUpdatePosition = new Vector2(newPosition.x, -0f);

        transform.position = newPosition;

        if (newPosition.y >= MaxPosition.y) 
        {
            transform.position = (MaxYUpdatePosition);
        }
        if (newPosition.y <= MinPosition.y)
        {
            transform.position = (MinYUpdatePosition);
        }
        if (newPosition.x > MaxPosition.x)
        {
            transform.position = (MaxXUpdatePosition);
        }
        if (newPosition.x < MinPosition.x)
        {
            transform.position = (MinXUpdatePosition);
        }    
    }
    public void SpeedUp()
    {
        SetSpeed(Movespeed += 1.0f);

    }
    public void SpeedDown()

    {
        SetSpeed(Movespeed -= 1.0f);
        
        
    }
    public float GetSpeed()
    {
        return Movespeed;
    }
    public float SetSpeed(float speed)
    {
        return speed;
    }

}