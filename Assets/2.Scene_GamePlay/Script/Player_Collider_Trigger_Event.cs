using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player_Collider_Trigger_Event : MonoBehaviour
{
    public GameObject enemy;
    public AudioClip[] collisionSound;
    public bool Checkcollider;

    void Awake()
    {
        Checkcollider = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy && Checkcollider == false)
        {
            AudioSource.PlayClipAtPoint(collisionSound[Random.Range(0,collisionSound.Length)],transform.position);
            Debug.Log("범위 충돌함");
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy && Checkcollider == true)
        {
            Checkcollider = false;
        }
    }
}