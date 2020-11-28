using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public Vector2 respawnPosition;

    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;

    public Image[] lives;
    public int livesRemaining;

   // public float damage;
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
            LoseLife();
            transform.position = respawnPosition;
            currentHealth = maxHealth;

        }
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
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            currentHealth -= EnemyBehaviour.Damage;

        }
        if (collision.gameObject.tag.Equals("Death"))
        {
            GameOver_Canvas.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("hit death");
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

        }

    }

}
