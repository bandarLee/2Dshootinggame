using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static Bullet;


public class Enemy : MonoBehaviour
{
    public Animator MyAnimator;


    public enum EnemyType
    {
        Basic = 0,
        Target,
        Follow
        
    }

    private float Movespeed = 3f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public int enemyhealth;
    public EnemyType enemytype;
    private GameObject _target;
    public Vector2 dir1;
    public Vector2 dir2;
    public Vector2 dir3;
    public GameObject itemprefeb; 
    public GameObject itemprefeb2;
    public AudioSource enemydamage;
    public AudioSource enemydie;
    public GameObject explosion;
    float angle;

    void Start()
    {
        GameObject SoundController1 = GameObject.Find("SoundController_zombiehit");
        GameObject SoundController2 = GameObject.Find("SoundController_zombiedie");
        enemydamage = SoundController1.GetComponent<AudioSource>();
        enemydie = SoundController2.GetComponent<AudioSource>();
        //캐싱기법
        _target = GameObject.Find("Player");
        MyAnimator = GetComponent<Animator>();

        if (enemytype == EnemyType.Target)
        {
            if (_target != null)
            {
                angle = Mathf.Atan2(_target.transform.position.y - transform.position.y, _target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                //transform.eulerAngles = new Vector3(0, 0, angle - 90)
                dir2 = _target.transform.position - this.transform.position;
            }
            dir2.Normalize();

        }


    }




void Update()
    {



        Vector2 dir = Vector2.down;
        Vector2 dir3 = _target.transform.position - this.transform.position;
        Vector3 direction = (_target.transform.position - this.transform.position).normalized;
        dir3.Normalize();
        if ((enemytype == EnemyType.Target))
        {
     

            transform.position += (Vector3)(dir2 * Movespeed * Time.deltaTime);
            

        }
        if (enemytype == EnemyType.Basic)
        {
            transform.position += (Vector3)(dir * Movespeed * Time.deltaTime);
        }

        if (enemytype == EnemyType.Follow)
        {
            angle = Mathf.Atan2(_target.transform.position.y - transform.position.y, _target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);
        //transform.LookAt(_target.transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject playerGameObject = GameObject.Find("ScoreManager");
        ScoreManager scoreManager = playerGameObject.GetComponent<ScoreManager>();
        GameObject Player = GameObject.Find("Player");
        Player player = Player.GetComponent<Player>();
        MyAnimator.Play("Hit");

            enemydamage.Play();
            
            
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (collision.gameObject.CompareTag("Player"))
        {
            int lifecount = player.Getlifecount();

            //충돌을 시작했을때 한번
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            player.Minuslifecount();
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            if (lifecount == 0)
            {
                Destroy(collision.gameObject);
            }
        }



        if (bullet != null)
        {
            if (bullet.Btype == BulletType.Main)
            {
                enemyhealth -= 2;
                Destroy(bullet.gameObject);

            }
            if (bullet.Btype == BulletType.Main)
            {
                enemyhealth -= 2;
                Destroy(bullet.gameObject);

            }
            else if (bullet.Btype == BulletType.Ult)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);

                enemydie.Play();
                SetItemRate();

                Destroy(this.gameObject);
                int score = scoreManager.GetScore();

                scoreManager.SetScore(score + 1);

            }
        }




        if (enemyhealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity) ;

            enemydie.Play();

            SetItemRate();
            Destroy(this.gameObject);
            int score = scoreManager.GetScore();
            scoreManager.SetScore(score + 1);


        }
    }
    private void SetItemRate()
    {
        int ItemRate = UnityEngine.Random.Range(0, 100);
        if (ItemRate < 10)
        {
            GameObject item = Instantiate(itemprefeb);
            item.transform.position = this.transform.position;
        }
        if (ItemRate > 90)
        {
            GameObject item = Instantiate(itemprefeb2);
            item.transform.position = this.transform.position;
        }

    }

    IEnumerator MsecondCoroution()
    {
        var wait = new WaitForSeconds(2f);

        yield return wait;

    }

}
