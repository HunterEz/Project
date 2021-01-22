using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int health;
    public float speed;
    public int damage;
    public AudioSource myFi;
    public GameObject laser;
    public Transform shotPoint;
    private float timeBtwShot;
    private float timeBtwSplash;
    public float startTimeBtwShot;
    public float startTimeBtwSplash;
    private float normalSpeed;
    public AudioClip attack;
    public AudioClip lasatack;
    public AudioClip takedamdge;
    private playerControl player;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<playerControl>();
        normalSpeed = speed;
    }

    private void Update()
    {


   

        if (health <= 0)
        {

            anim.SetTrigger("Dead");
        }
        else{ 

       

      



        if (timeBtwShot <= 0)
        {
            anim.SetTrigger("lasattack");
            timeBtwShot = startTimeBtwShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }


        if (true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("isrunning", true);
        }
        else
        {
            anim.SetBool("isrunning", true);
        }
        }
    }

    public void Deathon()
    {
        Destroy(gameObject);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& timeBtwSplash <= 0)
        {
            anim.SetTrigger("attack");
            timeBtwSplash = startTimeBtwSplash;
        }
        else
        {
            timeBtwSplash -= Time.deltaTime;

        }
    }

    public void OnBossAttack()
    {
        player.health -= damage;
        timeBtwSplash = startTimeBtwSplash;
    }

    public void OnBossLaserAttack()
    {

        Instantiate(laser, shotPoint.position, transform.rotation);
        // myFi.PlayOneShot(purfire);
        timeBtwShot = startTimeBtwShot;
    }

        public void TakeDamage(int damage)
    {
        
        health -= damage;
    }
}

