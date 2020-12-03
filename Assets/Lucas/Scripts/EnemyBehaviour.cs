using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hitPoints;

    [SerializeField] private float maxHitPoints = 100;

    public static float Damage = 10f;


    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
    }

    void Update()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Dead");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Projectile"))
        {
            Debug.Log("Enemy Damaged");
            hitPoints -= Projectile.p_Damage;
            //Debug.Log("Enemy damaged");
            
        }
    }

}
