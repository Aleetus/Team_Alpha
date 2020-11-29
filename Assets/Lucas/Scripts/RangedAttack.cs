using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    //---------------------------------------------------------------------------------------
    // Attack Properties
    public GameObject go_projectile;

    public float fl_cool_down = 1F;
    private float fl_next_shot_time;

    private Transform tx_gun_pivot;

    void Start()
    {
        tx_gun_pivot = transform.Find("PivotPoint").transform;
    }//----

    void Update()
    {
        RotateWeapon();
        Attack();
    }//-----
    //===========================================================================================================================s
    public RangedAttack(GameObject go_projectile, float fl_cool_down, float fl_next_shot_time, Transform tx_gun_pivot)
    {
        this.go_projectile = go_projectile;
        this.fl_cool_down = fl_cool_down;
        this.fl_next_shot_time = fl_next_shot_time;
        this.tx_gun_pivot = tx_gun_pivot;
    }
    //============================================================================================================================
    void RotateWeapon()
    {
        // This uses the trigonometric function Tan to calcucualte the angle to rotate to look at the PC
        Vector2 _v2_cam_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _v2_position = transform.position;
        Vector2 _v2_difference = _v2_cam_pos - _v2_position;
        float _fl_angle = Mathf.Atan2(_v2_difference.y, _v2_difference.x) * Mathf.Rad2Deg;
        tx_gun_pivot.rotation = Quaternion.AngleAxis(_fl_angle, Vector3.forward);


    }//-----

    //---------------------------------------------------------------------------------------
    // Custom function for attack
    void Attack()
    {
        // Has the fire button (CTRL or mouse) been pressed and cooldown delay time passed 
        if (Input.GetButtonDown("Fire1") && Time.time > fl_next_shot_time)
        {
            // Create a bullet 1 at unit in front of the PC
            Instantiate(go_projectile, tx_gun_pivot.position + tx_gun_pivot.TransformDirection(Vector2.right), tx_gun_pivot.transform.rotation);

            // Reset cooldown time
            fl_next_shot_time = Time.time + fl_cool_down;
        }
    } // -----
}
