using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawn : MonoBehaviour
{
    [Header("적 프리펩")]
    public GameObject EnemyBasicPrefab; //적 프리펩
    public GameObject EnemyTargetPrefab; //적 프리펩
    public GameObject EnemyFollowPrefab; //적 프리펩


    [Header("적군 리스폰")]
    public GameObject EnemySpawner;       //에네미스폰장소 들
    public bool isDelay;
    public float Respawntime = 1f;

    public float time;
    public float Mintime = 0.5f;
    public float Maxtime = 1.5f;

    public float EnemyRandomDicision;
    private GameObject _target;

    void Start()
    {
        _target = GameObject.Find("Player");

    }
    void Update()
    {

        if (isDelay == false && _target != null)
        {
            SetRandomenemytype();
            SetRandomspawnTime(Mintime, Maxtime);

            isDelay = true;

            
        }
        if (isDelay)
        {

            time += Time.deltaTime;
            if (time >= Respawntime)
            {
                time = 0.0f;
                isDelay = false;
            }
        }
    }
    private void SetRandomspawnTime(float Mintime, float Maxtime)
    {
        Respawntime = Random.Range(Mintime, Maxtime);
    }
    private void SetRandomenemytype()
    {
        EnemyRandomDicision = Random.Range(0,100);
        if (EnemyRandomDicision < 30)
        {
            GameObject enemy= Instantiate(EnemyBasicPrefab);
            enemy.transform.position = this.transform.position;
        }
        else if (EnemyRandomDicision > 90)
        {
            GameObject enemy = Instantiate(EnemyFollowPrefab);
            enemy.transform.position = this.transform.position;


        }
        else 
        {
            GameObject enemy = Instantiate(EnemyTargetPrefab);
            enemy.transform.position = this.transform.position;
        }
    }
}
