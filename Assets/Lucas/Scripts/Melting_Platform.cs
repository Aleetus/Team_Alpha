using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting_Platform : MonoBehaviour
{
    Rigidbody2D rb;

    public Vector2 respawnPosition;

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
            Invoke("PlatNotActive", 1f);
            Invoke("Respawn", 5f);
        }
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
