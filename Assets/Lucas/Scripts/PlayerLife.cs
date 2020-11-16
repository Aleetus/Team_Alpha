using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;

    public float damage;
    public Text T_GameOver;

    void Start()
    {
        currentHealth = maxHealth; // The players health is set to the max health at the start.
    }

    void Update()
    {
        healthSlider.value = currentHealth; // Here we set the player health on the UI.

        if (Input.GetKey(KeyCode.H)) // This causes damage.
        {
            TakeDamage();
        }

        if (currentHealth <= 0) // If the player health is 0 they die.
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();
        }
    }

    void TakeDamage() // This is what removes helath from the player.
    {
        currentHealth -= damage;
    }

    void Death()  // This Kills the player.
    {
        gameObject.SetActive(false);
        healthSlider.value = 0;
        
        //T_GameOver.text.setActive(true);
        
        //Destroy(gameObject);
    }
    
}
