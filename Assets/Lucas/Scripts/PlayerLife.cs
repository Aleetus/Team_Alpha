﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Vector2 respawnPosition;

    //[SerializeField] Transform projectileSpawnPos;
    //[SerializeField] GameObject projectile;

    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;

    public Image[] lives;
    public int livesRemaining;

    //audio
    public AudioSource gameOverSound;
    public AudioSource loseLifeSound;

    public GameObject GameOver_Canvas;


    void Start()
    {
        GameOver_Canvas.SetActive(false);

        respawnPosition = transform.position;

        currentHealth = maxHealth; // The players health is set to the max health at the start.
    }

    void Update()
    {
        healthSlider.value = currentHealth; // Here we set the player health on the UI.

        if (currentHealth <= 0) // If the player health is 0 they lose a life.
        {
            loseLifeSound.Play();
            LoseLife();
            transform.position = respawnPosition;
            currentHealth = maxHealth;
        }

        //if (Input.GetKey(KeyCode.Mouse0))
        //{
            //GameObject p = Instantiate(projectile);
            //p.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);

       // }



    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Health"))
        {
            if (currentHealth == maxHealth)
            {
                return;
            }
            if (currentHealth < maxHealth)
            {
                Debug.Log("health Picked up");
                currentHealth += HealthPickup.healthBoost;
            }
        }

        if (collider.gameObject.tag.Equals("Hazard"))
        {
            currentHealth -= HazardDamage.Damage;
        }
        if (collider.gameObject.tag.Equals("Death"))
        {
            currentHealth -= DeathTouch.Damage;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            currentHealth -= EnemyBehaviour.Damage;
        }
    }

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;

        livesRemaining--;
        lives[livesRemaining].enabled = false;

        if (livesRemaining == 0)
        {
            GameOver_Canvas.SetActive(true);
            gameObject.SetActive(false);
            gameOverSound.Play();

        }

    }

}
