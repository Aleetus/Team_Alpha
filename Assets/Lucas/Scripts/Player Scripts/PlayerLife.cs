using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    //Respawn
    public Vector2 respawnPosition;

    //Health
    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;

    public Image[] lives;
    public int livesRemaining;

    //audio
    public AudioSource gameOverSound;
    public AudioSource loseLifeSound;

    //GameOver
    public GameObject GameOver_Canvas;


    void Start()
    {
        GameOver_Canvas.SetActive(false);                    // The Game Over UI is deactiviated at the start.

        respawnPosition = transform.position;                // The respawn position is the position the player starts the level on.

        currentHealth = maxHealth;                           // The players health is set to the max health at the start.
    }

    void Update()
    {
        healthSlider.value = currentHealth;                  // Here we set the player health on the UI.

        if (currentHealth <= 0)                              // If the player health is 0 they lose a life.
        {
            loseLifeSound.Play();
            LoseLife();                                      // Runs the Lose Life Function.
            transform.position = respawnPosition;            // Sets the player position to the start point.
            currentHealth = maxHealth;                       // Sets the player health bar back to full.

        }


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Health"))        // Up on collision with a "Health" Tagged GameObject:
        {
            if (currentHealth == maxHealth)
            {
                return;
            }
            if (currentHealth < maxHealth)
            {
                Debug.Log("health Picked up");
                currentHealth += HealthPickup.healthBoost;   // Health boost value will be added to the players current health.
            }
        }
        if (collider.gameObject.tag.Equals("Death"))         // Up on collision with a "Death" Tagged GameObject:
        {
            currentHealth -= DeathTouch.Damage;              // Damage Value is removed from the player current health.
        }


    }
    private void OnTriggerStay2D(Collider2D collideWith)
    {
        if (collideWith.gameObject.tag.Equals("Hazard"))     // Upon collision with a "Hazard" Tagged GameObject:
        {
            currentHealth -= HazardDamage.Damage;            // Damage Value is removed from the player current health.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))        // Up on collision with a "Enemy" Tagged GameObject:
        {
            currentHealth -= EnemyBehaviour.Damage;          // Damage Value is removed from the player current health.
        }
        if (collision.gameObject.tag.Equals("FallingSpike"))
        {
            currentHealth -= FallingSpike.Damage;
        }
    }

    public void LoseLife()
    {
        if (livesRemaining == 0)                             
            return;

        livesRemaining--;                                    // When this function is ran one life is removed from the livesremaining.
        lives[livesRemaining].enabled = false;               // One Life Image is diabled.

        if (livesRemaining == 0)                             // When the livesReamining reaches 0:
        {
            gameOverSound.Play();                            // Sound plays.
            GameOver_Canvas.SetActive(true);                 // Game Over Canvas is set to visible.
            gameObject.SetActive(false);                     // Player Game Object is deactivated.


        }

    }

}
