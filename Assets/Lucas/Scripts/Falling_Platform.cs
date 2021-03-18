using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platform : MonoBehaviour
{
    Rigidbody2D rb;

    public Vector2 respawnPosition;
    public bool respawnPlatform;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Invoke("PlatformDrop", 0.5f);
            Invoke("PlatNotActive", 1f);
            if (respawnPlatform == true)
            {
                Invoke("Respawn", 10f);
            }
        }
    }

    void PlatformDrop()
    {
        rb.isKinematic = false;
    }

    void PlatNotActive()
    {
        gameObject.SetActive(false);
        rb.isKinematic = true;
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        gameObject.SetActive(true);
    }
}
