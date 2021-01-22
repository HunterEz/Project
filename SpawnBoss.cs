using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour

{ 

    public GameObject spawn;
    public GameObject boss;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            boss.transform.position = spawn.transform.position;
            Instantiate(boss, boss.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

