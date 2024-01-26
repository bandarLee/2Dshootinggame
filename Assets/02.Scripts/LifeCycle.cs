using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private void Awake()//���� ������Ʈ�� �ν��Ͻ�ȭ(�����) ȣ���̵�
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
