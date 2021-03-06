using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Dead_Trigger : MonoBehaviour
{
    
    public GameObject player;
    public AudioClip[] collisionSounds;
    private LoadScene loadScene;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {            
            loadScene = GameObject.Find("Dead_Player").GetComponent<LoadScene>();
            StartCoroutine(loadScene.transitionNextScene(SceneManager.GetActiveScene().buildIndex,1));
            AudioSource.PlayClipAtPoint(collisionSounds[Random.Range(0,collisionSounds.Length)],transform.position);
            Debug.Log("범위");
        }   
    }
}