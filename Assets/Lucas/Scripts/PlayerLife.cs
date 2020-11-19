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

        if (currentHealth <= 0) // If the player health is 0 they die.
        {
            Death();
        }
    }

    void Death()  // This Kills the player.
    {
        gameObject.SetActive(false);
        healthSlider.value = 0;
        //T_GameOver.text.SetActive(true);
    }
    
}
