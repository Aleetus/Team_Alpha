using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTakeOff : MonoBehaviour
{
    public GameObject enemyShip;
    public float speed;
    public bool isFlying;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isFlying = true;
        }
    }

}
