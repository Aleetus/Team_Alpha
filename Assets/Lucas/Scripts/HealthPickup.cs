using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerLife playerHealth;

    public static float healthBoost = 20f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);

        }
    }
}
