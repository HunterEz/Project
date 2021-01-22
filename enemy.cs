using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject deathEffect;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private playerControl player;
    private Animator anim;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public AudioSource mySu;
    public AudioClip death;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<playerControl>();
        normalSpeed = speed;
    }

    private void Update()
    {
    

       

        if (stopTime <=0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }

        if (health <=0)
        {
            mySu.PlayOneShot(death);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

            if(true)
        { 
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            anim.SetBool("isrunning", true);
        }
        else
        {
            anim.SetBool("isrunning", true);
        }
      

    }

    public void TakeDamage(int damage)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        stopTime = startStopTime;
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("attack");
         
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
           
        }
    }

    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
