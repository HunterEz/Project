using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemfly : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;
   // public AudioSource mySu;
    public AudioSource myFi;
    public AudioClip death;
    public GameObject fire;
    public Transform shotPoint;
    private float timeBtwShot;
    public float startTimeBtwShot;
    public AudioClip purfire;


    private void Update()
    {
        if (health <= 0)
        {
            myFi.PlayOneShot(death);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (timeBtwShot <= 0)
        {
            Instantiate(fire, shotPoint.position, transform.rotation);
            myFi.PlayOneShot(purfire);
            timeBtwShot = startTimeBtwShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }
    }




    public void TakeDamage(int damage)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
}
