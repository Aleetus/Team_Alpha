using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public AudioSource healthSound;

    public static float healthBoost = 20f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            healthSound.Play();
            gameObject.SetActive(false);

            Invoke("RespawnHealthBoost", 10);
        }

    }

    void RespawnHealthBoost()
    {
        gameObject.SetActive(true);
        Debug.Log("Health Boost Respawn!!!");
    }
}
