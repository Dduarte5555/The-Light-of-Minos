using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Animation : MonoBehaviour
{
    Animator ani;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();

        mousePos = new Vector2(0,0);
    }

    public static float FindDegree(float x, float y)
    {
        float value = (float)((Mathf.Atan2(x, y) / Math.PI) * 180f);
        if (value < 0) value += 360f;

        return value;
    }

    public static float RotateAngle(float angle, bool normalize = true)
    {
        // Convert the angle from degrees to radians.
        float angleInRadians = Mathf.Deg2Rad * angle;

        // Add π/4 to the angle.
        angleInRadians += Mathf.PI / 4;

        // Normalize the angle by taking the remainder when divided by 2π.
        if (normalize)
        {
            angleInRadians %= Mathf.PI * 2;
        }

        // Convert the angle back from radians to degrees.
        float normalizedAngle = Mathf.Rad2Deg * angleInRadians;

        // Return the normalized angle divided by 2π.
        return normalizedAngle / (2f * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;

        float angle = FindDegree(lookDir.x, lookDir.y);

        float rotatedAndle = angle + 45;
        float normalizedAngle;
        if (rotatedAndle > 360)
        {
            normalizedAngle = (rotatedAndle - 360) / 360;
        } else
        {
            normalizedAngle = angle / 360;
        }

        ani.SetFloat("MouseAngleNormalized", normalizedAngle);

        //Debug.Log("MouseAngleNormalized: " + normalizedAngle);

    }
}
