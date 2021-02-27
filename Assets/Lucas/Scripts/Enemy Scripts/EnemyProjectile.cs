using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float dieTime, damage;
    private Rigidbody2D rb_projectile;
    public float fl_speed = 5;


    void Start()
    {
        StartCoroutine(CountDownTimer());

        rb_projectile = GetComponent<Rigidbody2D>();
        rb_projectile.velocity = transform.TransformDirection(Vector2.left) * fl_speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerLife.currentHealth -= damage;
            //Die();
        }
        Die();

    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
        

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
