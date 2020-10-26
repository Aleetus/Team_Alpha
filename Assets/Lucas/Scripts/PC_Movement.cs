using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Movement : MonoBehaviour
{
    public float f_speed;


    // Update is called once per frame
    void Update()
    {
        lookatMouse();

        float x = Input.GetAxis("Horizontal"); // This will have a value of -1 for left, 0 for no input and 1 for right.
        float y = Input.GetAxis("Vertical"); // This will have a value of -1 for down, 0 for no input and 1 for up.

        // This computes a direction vector based on the input and normalizes to get a unit vector.
        Vector2 direction = new Vector2(x, y).normalized;

        Move (direction);
    }

    void Move(Vector2 direction)
    {
        // Get the player's current position
        Vector2 pos = transform.position;

        // Calculate new position
        pos += direction * f_speed * Time.deltaTime;

        // Update player's position
        transform.position = pos;
    }

    void lookatMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }

}
