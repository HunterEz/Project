using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{

    public AudioSource mySu;
    public AudioSource mySuJ;
    public AudioClip lose;
    public AudioClip jump;

    public float speed = 20f;

    public float JumpForce = 10000f;

    private Rigidbody2D rb;

    public GameObject BloodEffect;

    private float moveInput;

    public float health;

    private Animator anim;

    public float heal;

    private bool faceRight = true;

    bool inAir;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent <Rigidbody2D> ();

    }

    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        health += Time.deltaTime * heal;
        for(int i=0; i< hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i <numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if(health< 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        float moveX = Input.GetAxis ("Horizontal");

            rb.MovePosition(rb.position + Vector2.right * moveInput * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && !inAir)
            {
                mySuJ.PlayOneShot(jump);
                rb.AddForce(Vector2.up * JumpForce); 
                inAir = true;      
                anim.SetTrigger("takeoff");
            }

        if (moveInput > 0 && !faceRight)
            flip();
        else if (moveInput < 0 && faceRight)
            flip();

        if(moveInput == 0)
        {
            anim.SetBool("isruning", false);
        }
        else
        {
            anim.SetBool("isruning", true);
        
        }

        if (health <= 0)
        {
            mySu.PlayOneShot(lose);
            Instantiate(BloodEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (!inAir)
        {
            anim.SetBool("isjump", false);
        }
        else
        {
            anim.SetBool("isjump", true);
        }
    }
     
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            inAir = false;
    }

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    } 
}
