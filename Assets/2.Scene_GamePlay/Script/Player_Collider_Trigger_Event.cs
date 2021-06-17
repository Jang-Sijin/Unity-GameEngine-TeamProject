using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collider_Trigger_Event : MonoBehaviour
{
    public GameObject enemy;
    public AudioClip[] collisionSound;
    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            AudioSource.PlayClipAtPoint(collisionSound[Random.Range(0,collisionSound.Length)],transform.position);
            Debug.Log("범위 충돌함");
        }   
    }
}
