using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private void Awake()//게임 오브젝트가 인스턴스화(깨어날때) 호출이됨
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        
        Debug.Log("OnEnable");

    }
    private void Start()
    {
        Debug.Log("Start");
    }
    private void Update()
    {
        
    }
    private void LateUpdate()
    {

    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");

    }
}
