using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public float time;
    public float ultimateTime = 0.5f;

    void Start()
    {
        /*GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }*/
    }

    void Update()
    {
       time += Time.deltaTime;
       
        if (time >= ultimateTime)
          { 
            this.gameObject.SetActive(false);
          }

    }
}

