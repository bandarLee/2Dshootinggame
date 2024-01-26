using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _lifecount = 3;

    public TMP_Text Life;
    public GameObject explosion;

    private void Start()
    {

    }

    private void Update()
    {
        Life.text = $"Life count {_lifecount}";

    }


    public void Addlifecount()
    {
        _lifecount++;
    }
    public void Minuslifecount()
    {
        _lifecount--;

    }
    public int Getlifecount()
    {
        return _lifecount; 
    }
}
