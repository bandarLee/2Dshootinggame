using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawn : MonoBehaviour
{
    [Header("�� ������")]
    public GameObject EnemyBasicPrefab; //�� ������
    public GameObject EnemyTargetPrefab; //�� ������
    public GameObject EnemyFollowPrefab; //�� ������

    public int PoolSize = 15;
    private List<Enemy> EnemyPool;


    [Header("���� ������")]
    public GameObject EnemySpawner;       //���׹̽������ ��
    public bool isDelay;
    public float Respawntime = 1f;

    public float time;
    public float Mintime = 0.5f;
    public float Maxtime = 1.5f;

    public float EnemyRandomDicision;
    private GameObject _target;
    private void Awake()
    {
        EnemyPool = new List<Enemy>();
        //(���� -> ���� -> �ִ´�) * PoolSize(15).
        for(int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = Instantiate(EnemyBasicPrefab);
            enemyObject.SetActive(false);
            EnemyPool.Add(enemyObject.GetComponent<Enemy>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = Instantiate(EnemyTargetPrefab);
            enemyObject.SetActive(false);
            EnemyPool.Add(enemyObject.GetComponent<Enemy>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject enemyObject = Instantiate(EnemyFollowPrefab);
            enemyObject.SetActive(false);
            EnemyPool.Add(enemyObject.GetComponent<Enemy>());
        }
    }
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
        Enemy enemy = null;
        EnemyRandomDicision = Random.Range(0,100);
        if (EnemyRandomDicision < 30)
        {
            foreach(Enemy e in EnemyPool)
            {
                if(!e.gameObject.activeInHierarchy && e.enemytype == EnemyType.Basic)
                {
                    enemy = e;
                    enemy.gameObject.SetActive(true);

                    break;
                }
            }
            enemy.transform.position = this.transform.position;
        }
        else if (EnemyRandomDicision > 90)
        {
            foreach (Enemy e in EnemyPool)
            {
                if (!e.gameObject.activeInHierarchy && e.enemytype == EnemyType.Target)
                {
                    enemy = e;
                    enemy.gameObject.SetActive(true);

                    break;
                }
            }
            enemy.transform.position = this.transform.position;


        }
        else 
        {
            foreach (Enemy e in EnemyPool)
            {
                if (!e.gameObject.activeInHierarchy && e.enemytype == EnemyType.Follow)
                {

                    enemy = e;
                    enemy.gameObject.SetActive(true);

                    break;

                }

            }
            enemy.transform.position = this.transform.position;
        }
    }
}
