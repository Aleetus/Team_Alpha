using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public static float healthBoost = 20f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);

        Invoke("RespawnHealthBoost", 10);
    }

    void RespawnHealthBoost()
    {
        gameObject.SetActive(true);
        Debug.Log("Health Boost Respawn!!!");
    }
}
