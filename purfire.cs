﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purfire : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damdge;
    public LayerMask whatIsSolid;
    private playerControl player;

    void Start()
    {
       
        player = FindObjectOfType<playerControl>();
      
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Player"))
            {
                player.health -= damdge;
               
            }
            Destroy(gameObject);

        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
