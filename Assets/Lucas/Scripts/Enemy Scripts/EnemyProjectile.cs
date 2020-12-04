using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float dieTime, damage;


    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerLife.currentHealth -= damage;
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
