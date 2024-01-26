using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public float scrollspeed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 dir = Vector2.down;
        Vector2 currentposition = transform.position + (Vector3)(dir * scrollspeed * Time.deltaTime);

        if(currentposition.y < -22.22f)
        {

            currentposition.y = 1.25f;

        }
        transform.position = currentposition;

        //0.93, -12.5
    }
}
