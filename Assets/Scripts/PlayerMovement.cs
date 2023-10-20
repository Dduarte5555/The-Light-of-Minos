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
    Animator ani;

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

        ani = this.GetComponent<Animator>();
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

        //Debug.Log(movement);
        if (movement != Vector2.zero)
        {
            ani.SetBool("PlayerIsMoving", true);
        }
        else
        {
            ani.SetBool("PlayerIsMoving", false);
        }
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
