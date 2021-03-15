using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public static float Damage = 30f;
    public float dropTime = 1f;
    public float respawnTime = 10f;

    Rigidbody2D rb;
    public Vector2 respawnPosition;

    [SerializeField] private Animator myAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            myAnimationController.SetBool("Shake", true);
            Invoke("PlatformDrop", dropTime);
            Invoke("Respawn", respawnTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    void PlatformDrop()
    {
        rb.isKinematic = false;
    }
    void Respawn()
    {
        transform.position = respawnPosition;
        rb.isKinematic = true;
        gameObject.SetActive(true);
    }
}
