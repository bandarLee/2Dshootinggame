using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Bullet;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public Animator MyAnimatior;

    public enum ItemType
    {
        Health = 0,
        Move = 1
    }
    public ItemType Itype; //0¿Ã∏È ¡÷√—æÀ, 1¿Ã∏È ∫∏¡∂√—æÀ 2∏È ∆‰¿ÃΩÓ¥¬√—æÀ

    public bool isDelay;
    public float caneatitem = 1f;
    public float time1;
    public int MyType = 0;
    public AudioSource ItemEatSource;
    public float time2;
    public float itemmove = 3;
    private GameObject _target;
    private float Movespeed = 3f;
    public Animator MyAnimator;
    public GameObject itemparticle;

    private void Awake()
    {
        MyAnimatior = this.GetComponent<Animator>();
        GameObject SoundController = GameObject.Find("SoundController_item");
        ItemEatSource = SoundController.GetComponent<AudioSource>();
    }
    private void Update()
    {
        _target = GameObject.Find("Player");

        Vector2 dir3 = _target.transform.position - this.transform.position;
        time2 += Time.deltaTime;
        if (time2 > itemmove)
        {
            transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);

        }
    }
    private void Start()
    {
        MyAnimatior.SetInteger("ItemType", (int)Itype);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        time1 += Time.deltaTime;



        switch (Itype) 
        {

            case ItemType.Health:

            if (time1 >= caneatitem)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GameObject playerGameObject = GameObject.Find("Player"); 
                    Player player = playerGameObject.GetComponent<Player>();
                    player.Addlifecount();


                    ItemEatSource.Play();
                    Instantiate(itemparticle, _target.transform.position, Quaternion.identity);

                    Destroy(this.gameObject);


                    }
                }
 
                break;
            case ItemType.Move:
                if (time1 >= caneatitem)
                {
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        GameObject playerGameObject = GameObject.Find("Player");
                        PlayerMove playermove = playerGameObject.GetComponent<PlayerMove>();
                        playermove.SpeedUp();
                        ItemEatSource.Play();
                        Instantiate(itemparticle, _target.transform.position, Quaternion.identity);
                        Destroy(this.gameObject);


                    }
                }

                break;
        }


        


    }

}
