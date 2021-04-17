using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFish : MonoBehaviour
{
    public Vector2 respawnPosition;

    private Rigidbody2D rb;

    public float range, timeBtwShots, shootSpeed;
    public Transform firePoint;
    public GameObject projectile;

    public Transform target;
    private bool searchingForPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        respawnPosition = transform.position;
        StartCoroutine(Shoot());

        if (target == null)
        {
            Debug.Log("No player Found, System Error!!!!");
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(searchForPlayer());
            }
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBtwShots);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        GameObject newProjectile = Instantiate(projectile, firePoint.position + firePoint.TransformDirection(Vector2.right), firePoint.transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        StartCoroutine(Shoot());
    }

    IEnumerator searchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(searchForPlayer());
            StartCoroutine(Shoot());
        }
        else
        {
            target = sResult.transform;
            searchingForPlayer = false;
            StartCoroutine(Shoot());
            yield return false;
        }
    }

    void ShootPlayer()
    {
        StartCoroutine(Shoot());

    }
}
