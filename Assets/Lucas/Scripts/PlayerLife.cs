using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;

    public Image[] lives;
    public int livesRemaining;

    public float damage;
    public GameObject GameOver_Canvas;


    void Start()
    {
        GameOver_Canvas.SetActive(false);

        currentHealth = maxHealth; // The players health is set to the max health at the start.
    }

    void Update()
    {
        healthSlider.value = currentHealth; // Here we set the player health on the UI.

        if (currentHealth <= 0) // If the player health is 0 they die.
        {
            LoseLife();
            currentHealth = maxHealth;
            //gameObject.transform.position = spawnPoint.transform;
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
