using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("ÃÑ¾Ë ÇÁ¸®Æé")]
    public GameObject BulletPrefab; //ÃÑ¾Ë ÇÁ¸®Æé
    [Header("º¸Á¶¹«±â ÇÁ¸®Æé")]
    public GameObject SubBulletPrefab; //ÃÑ¾Ë ÇÁ¸®Æé
    [Header("ÇÊ»ì±â")]
    public GameObject UltimatePrefab; //ÃÑ¾Ë ÇÁ¸®Æé
    [Header("ÃÑ±¸")]
    public GameObject[] Muzzles;       //ÃÑ±¸ µé
    [Header("º¸Á¶ÃÑ±¸")]
    public GameObject[] SubMuzzles;       //ÃÑ±¸ µé
    public AudioSource FireSource;
    public float Movespeed = 30f;
    public bool isDelay;
    public bool ultimateDelay;
    public bool ultimatePlay;

    public float delayTime = 0.6f;
    public float ultimateDelayTime = 3f;

    public float time1;
    public float time2;
    public bool Auto = false;
    public GameObject ultimate;

    void Start()
    {

    }

    void Update()
    {
        //¹ß»ç¹öÆ°À» ´©¸£¸é

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Auto = true;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Auto = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ultimateDelay == false)
            {
                ultimateDelay = true;
                ultimate = Instantiate(UltimatePrefab);
                ultimate.transform.position = Muzzles[2].transform.position;
            }
        }

        if (Auto)
        {
            if (isDelay == false)
            {
                isDelay = true;


                for (int i = 0; i < Muzzles.Length; i++)
                {
                    GameObject bullet = Instantiate(BulletPrefab);

                    bullet.transform.position = Muzzles[i].transform.position;
                    FireSource.Play();
                }
                for (int i = 0; i < SubMuzzles.Length; i++)
                {
                    GameObject subbullet = Instantiate(SubBulletPrefab);

                    subbullet.transform.position = SubMuzzles[i].transform.position;

                }
            }

        }

    
        if (Auto == false && Input.GetKey(KeyCode.Space))
        {
            if (isDelay == false)
            {
                isDelay = true;


                for (int i = 0; i < Muzzles.Length; i++)
                {
                    FireSource.Play();

                    GameObject bullet = Instantiate(BulletPrefab);

                    bullet.transform.position = Muzzles[i].transform.position;
                }
                for (int i = 0; i < SubMuzzles.Length; i++)
                {
                    GameObject subbullet = Instantiate(SubBulletPrefab);

                    subbullet.transform.position = SubMuzzles[i].transform.position;
                }
            }
        }
        if (isDelay)
        {
            time1 += Time.deltaTime;
            if (time1 >= delayTime)
            {
                time1 = 0.0f;
                isDelay = false;
            }

        }
        if (ultimateDelay)
        {
            time2 += Time.deltaTime;
            if (time2 >= ultimateDelayTime)
            {
                time2 = 0.0f;
                ultimateDelay = false;
            }

        }

    }
}
