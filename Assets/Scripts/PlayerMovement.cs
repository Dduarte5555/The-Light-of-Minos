using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    private PlayerLightManager lightManager;

    Vector2 movement;
    Vector2 mousePos;
    private bool isColliding = false;

    void Start()
    {
        lightManager = GetComponent<PlayerLightManager>();
        lightManager.InitializeLight();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        isColliding = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding)
        {
            return;
        }

        if (other.gameObject.CompareTag("labareda"))
        {
            Debug.Log("HIT");
            other.gameObject.SetActive(false);
            lightManager.IncreaseLight(0.1f);
            isColliding = true;
        }
    }
}
