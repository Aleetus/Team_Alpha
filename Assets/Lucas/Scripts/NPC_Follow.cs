using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Follow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public Vector2 respawnPosition;

    private Rigidbody2D rb;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
            Invoke("Respawn", 10f);
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        gameObject.SetActive(true);
    }

}
