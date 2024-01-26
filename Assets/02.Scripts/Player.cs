using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lifecount = 3;

    public TMP_Text Life;
    public GameObject explosion;

    private void Start()
    {

    }

    private void Update()
    {
        Life.text = $"Life count {lifecount}";

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity) ;
            //�浹�� ���������� �ѹ�s
            Debug.Log("Enter");
            lifecount--;
        }

        if (lifecount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
