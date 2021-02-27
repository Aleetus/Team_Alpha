using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float range, timeBtwShots, shootSpeed;
    //private float distanceToPlayer;
    //public Transform targetPlayer;
    public Transform shootPos;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());

        //player = GameObject.find("PlayerCharacter")
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Shoot());

        //distanceToPlayer = Vector2.Distance(transform.position, targetPlayer.position);

        //if (distanceToPlayer <= range)
        //{
        //StartCoroutine(Shoot());
        //}
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBtwShots);
        GameObject newProjectile = Instantiate(projectile, shootPos.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        StartCoroutine(Shoot());

    }
}
