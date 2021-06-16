using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collider_Trigger_Event : MonoBehaviour
{
    public GameObject enemy;

    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            Debug.Log("범위 충돌함");
        }   
    }
}
