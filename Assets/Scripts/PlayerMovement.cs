using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    private PlayerLightManager lightManager;

    public Light2D playerLight;
    private float initialOuterRadius = 5f;

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

    public void IncreaseLight()
    {
        playerLight.intensity = 1;
        playerLight.pointLightOuterRadius = playerLight.intensity * initialOuterRadius;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding)
        {
            return;
        }

        if (other.gameObject.CompareTag("labareda"))
        {
            other.gameObject.SetActive(false);
            lightManager.IncreaseLight(0.1f);
            isColliding = true;
        }

        else if (other.gameObject.CompareTag("Tocha"))
        {
            IncreaseLight();
            isColliding = true;
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Health playerHealth = GetComponent<Health>();

            playerHealth.OnHit(1, other.gameObject);

            isColliding = true;
        }

        else if (other.gameObject.CompareTag("EnemyMaster"))
        {
            SceneManager.LoadScene(0);
            isColliding = true;
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            rb.position = new Vector3(160f, 25f, 0f);
            isColliding = true;
        }
        else if (other.gameObject.CompareTag("Exit_final"))
        {
            SceneManager.LoadScene("Scenes/Sucesso");
            isColliding = true;
            
        }
    }
}
