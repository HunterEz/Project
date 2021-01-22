using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public AudioSource mySu;
    public AudioClip sword;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;
    public int checke;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                anim.SetTrigger("attack");
                mySu.PlayOneShot(sword);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }


    }

    private void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            if(checke == 1)
            { 
            enemies[i].GetComponent<enemy>().TakeDamage(damage);
            }
            if (checke == 2)
            {
                enemies[i].GetComponent<enemfly>().TakeDamage(damage);
            }
            if (checke == 3)
            {
                enemies[i].GetComponent<Boss>().TakeDamage(damage);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            checke = 1;
        }
        if (other.CompareTag("enemfly"))
        {
            checke = 2;

        }
        if (other.CompareTag("boss"))
        {
            checke = 3;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
