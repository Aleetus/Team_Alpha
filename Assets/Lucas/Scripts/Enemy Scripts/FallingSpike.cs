﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public static float Damage = 30f;

    Rigidbody2D rb;
    public Vector2 respawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Invoke("PlatformDrop", 0.2f);
            Invoke("Respawn", 10f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    void PlatformDrop()
    {
        rb.isKinematic = false;
    }
    void Respawn()
    {
        transform.position = respawnPosition;
        rb.isKinematic = true;
        gameObject.SetActive(true);
    }
}
