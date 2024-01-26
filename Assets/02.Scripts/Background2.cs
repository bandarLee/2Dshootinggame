using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2 : MonoBehaviour
{
    public float Scrollspeed = 0.2f;
    public Material Mymaterial;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 dir = Vector2.up;
        Mymaterial.mainTextureOffset += dir * Scrollspeed * Time.deltaTime;
    }
}
