using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    private void OncolliderEnter2D(Collider2D othercollider)
    {

        if(othercollider.tag == "bullet")
        {
        }
            Destroy(othercollider.gameObject);



    }
}
