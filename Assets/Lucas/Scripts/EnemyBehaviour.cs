using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 5;


    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
    }

    void TakeHit(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
