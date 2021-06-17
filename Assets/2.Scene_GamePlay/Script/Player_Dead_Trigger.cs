using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dead_Trigger : MonoBehaviour
{
    
    public GameObject player;
    public AudioClip[] collisionSounds;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(collisionSounds[Random.Range(0,collisionSounds.Length)],transform.position);
            Debug.Log("범위 충돌함");
        }   
    }
}
