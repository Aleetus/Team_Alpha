using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float fl_speed = 5;
    public float fl_range = 10;
    private Rigidbody2D rb_projectile;

    public static float damage = 25f;

    //---------------------------------------------------------------------------------------  

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * fl_speed);


        // Remove this object from the scene when the range is reached 
        Destroy(gameObject, fl_range / Mathf.Abs(fl_speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerLife.currentHealth -= damage;
        }
        Destroy(gameObject);
    }
}
