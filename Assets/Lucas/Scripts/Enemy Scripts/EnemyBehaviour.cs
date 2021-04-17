using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hitPoints, respawnTimer;

    [SerializeField] private float maxHitPoints = 100;

    public static float Damage = 10f;

    public static float waspDamage = 20f;


    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
    }

    void Update()
    {
        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("Enemy Dead");
            Invoke("RespawnEnemy", respawnTimer);
        }
    }

    void RespawnEnemy()
    {
        hitPoints = maxHitPoints;
        gameObject.SetActive(true);
        Debug.Log("Enemy Respawn!!!");
        //TurretFish.ShootPlayer();
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
