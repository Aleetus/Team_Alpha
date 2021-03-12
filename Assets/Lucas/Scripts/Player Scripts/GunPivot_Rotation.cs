using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot_Rotation : MonoBehaviour
{
    public int rotation_offset = 90;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;  // Subtracting the position of the player from the mouse posisition.
        difference.Normalize();      // The sum of the vectors will be equal to 1.

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // Finding the angle in degrees.
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotation_offset);
    }
}
