using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemySpawnPoint;
    private float activeEnemies = 0;

    private Collider2D m_Collider;

    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (activeEnemies >= 1)
        {
            m_Collider.enabled = !enabled;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))        // Up on collision with a "Player" Tagged GameObject:
        {
            StartCoroutine(RespawnEnemy());
            //gameObject.SetActive(false);

        }
    }


    public IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(0);
        Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        activeEnemies += 10;
    }
}
