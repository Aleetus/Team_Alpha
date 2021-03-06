﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 20;
    public LayerMask whatToHit;
    float timeToFire = 0;
    Transform firePoint;
    public GameObject projectile;
    public AudioSource shootSound;

    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find ("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("No FirePoint ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Instantiate(projectile, firePoint.position + firePoint.TransformDirection(Vector2.right), firePoint.transform.rotation);
        
        shootSound.Play();
        Debug.Log("BulletFired");
    }
}
