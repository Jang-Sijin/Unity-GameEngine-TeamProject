using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public float speed = 30.0f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trans = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(trans);
        transform.position += ((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
