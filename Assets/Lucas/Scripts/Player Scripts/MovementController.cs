using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float f_BoostForce;
    private Rigidbody2D rb;
    private bool bl_IsBoosting = false;

    public Camera myCamera; // set camera from the scene.
    public Transform cameraTarget; // target of the camera to move to.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        LookAtMouse();
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * f_BoostForce * Time.deltaTime);
            //rb.AddRelativeForce(Vector2.right * f_BoostForce * Time.deltaTime);
            bl_IsBoosting = true;
        }
        else if(!Input.GetKey(KeyCode.W) && bl_IsBoosting)
        {
            bl_IsBoosting = false;
        }
    }

    void LookAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
