using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("총알 프리펩")]
    public GameObject BulletPrefab; //총알 프리펩

    [Header("보조무기 프리펩")]
    public GameObject SubBulletPrefab; //총알 프리펩

    public int PoolSize = 20;
    private List<GameObject> _bulletPool;
    private List<GameObject> _subBulletPool;
    public bool UltimateButton = false;
    public bool YButton = false;
    public bool AButton = false;
    public bool XButton = false;





    void Awake()
    {
        _bulletPool = new List<GameObject>();
        _subBulletPool = new List<GameObject>();

        for (int i = 0; i < PoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.SetActive(false);
            _bulletPool.Add(bullet);

            GameObject subBullet = Instantiate(SubBulletPrefab);
            subBullet.SetActive(false);
            _subBulletPool.Add(subBullet);
        }
    }

    GameObject GetPooledObject(List<GameObject> pool, GameObject prefab)
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        GameObject newObject = Instantiate(prefab);
        newObject.SetActive(false);
        pool.Add(newObject);

        return newObject;
    }

    [Header("필살기")]
    public GameObject UltimatePrefab; //총알 프리펩
    [Header("총구")]
    public List<GameObject> Muzzles = new List<GameObject>();


    [Header("보조총구")]
    public List<GameObject> SubMuzzles = new List<GameObject>();
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
        //발사버튼을 누르면

        if(Input.GetKeyDown(KeyCode.Alpha1) )
        {
            YButton = true;
        }
        if (YButton)
        {
            Auto = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            YButton = false;
            Auto = false;
        }
        if (!YButton)
        {
            Auto = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || UltimateButton)
        {
            Ultimate();
        }

        if (Auto)
        {

            AutoMode();
        }

    
        if (Auto == false && (Input.GetKey(KeyCode.Space) || XButton))
        {
            NonAutoMode();
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
    public void OnClickAButton()
    {
        Debug.Log("A버튼 클릭");
    }
    public void OnClickXButton()
    {
        Debug.Log("X버튼 클릭");
        XButton = true;
    }
    public void OnClickBButton()
    {
        Debug.Log("B버튼 클릭");
        UltimateButton = true;

    }
    public void OnClickYButton()
    {
        Debug.Log("Y버튼 클릭");
        if(!YButton){
            YButton = true;
        }
        else if (YButton)
        {
            YButton = false;
        }
    }
    public void Ultimate()
    {
        if (ultimateDelay == false)
        {
            ultimateDelay = true;
            ultimate = Instantiate(UltimatePrefab);
            ultimate.transform.position = Muzzles[2].transform.position;
            UltimateButton = false;
        }
    }
    public void AutoMode()
    {
        if (isDelay == false)
        {
            isDelay = true;


            for (int i = 0; i < Muzzles.Count; i++)
            {
                GameObject bullet = GetPooledObject(_bulletPool, BulletPrefab);
                bullet.transform.position = Muzzles[i].transform.position;
                bullet.SetActive(true);
                FireSource.Play();
            }
            for (int i = 0; i < SubMuzzles.Count; i++)
            {
                GameObject subBullet = GetPooledObject(_subBulletPool, SubBulletPrefab);
                subBullet.transform.position = SubMuzzles[i].transform.position;
                subBullet.SetActive(true);


            }
        }

    }
    public void NonAutoMode()
    {
        if (isDelay == false)
        {
            isDelay = true;
            XButton = false;


            for (int i = 0; i < Muzzles.Count; i++)
            {
                FireSource.Play();

                GameObject bullet = Instantiate(BulletPrefab);

                bullet.transform.position = Muzzles[i].transform.position;
            }
            for (int i = 0; i < SubMuzzles.Count; i++)
            {
                GameObject subbullet = Instantiate(SubBulletPrefab);
                subbullet.transform.position = SubMuzzles[i].transform.position;
            }
        }
    }






}
