using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting_Platform : MonoBehaviour
{
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject, 1f);
        }
    }

    void PlatformDrop()
    {
        rb.isKinematic = false;
    }
}
