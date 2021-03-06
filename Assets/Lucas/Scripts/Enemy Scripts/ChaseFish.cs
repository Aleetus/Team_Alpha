﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseFish : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 respawnPosition;
    public Transform spawnPoint;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Transform target;
    private bool searchingForPlayer = false;

    public float detectRange = 20;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;

        if (target == null)
        {
            Debug.Log("No player Found, System Error!!!!");
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(searchForPlayer());
            }
            return;
        }
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.position);  // Calculates distance from player and enemy.
        if (distToPlayer < detectRange) // If the distance from the enemy to the player is less than the detect ran
        {
            moveCharacter(movement);
        }
        else
        {
            Invoke("Respawn", 0f);
            StartCoroutine(searchForPlayer());
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
            Invoke("Respawn", 0f);
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        gameObject.SetActive(true);
    }

    IEnumerator searchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
            
        }
        else
        {
            target = sResult.transform;
            searchingForPlayer = false;
            yield return false;
        }
    }
}
