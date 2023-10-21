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

    Vector2 movement;
    Vector2 mousePos;


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

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("labareda"))
        {
            other.gameObject.SetActive(false);
            lightManager.IncreaseLight(0.1f);
        }

        else if (other.gameObject.CompareTag("Tocha"))
        {
            TochaEvent tocha = other.gameObject.GetComponent<TochaEvent>();
            if (!tocha.HasLight()) 
            {
                return;
            }
            lightManager.IncreaseLight(0.1f);
            ani.SetBool("PlayerHasTorch", true);
            tocha.DisableLight();
        }

        else if (other.gameObject.CompareTag("EnemyMaster"))
        {
            //SceneManager.LoadScene(0);
            ani.SetBool("PlayerIsDead",true);
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            rb.position = new Vector3(160f, 25f, 0f);
        }
        else if (other.gameObject.CompareTag("Exit_final"))
        {
            SceneManager.LoadScene("Scenes/Sucesso");
            FindObjectOfType<AudioManager>().Play("VictoryTheme");
        }
    }

     void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health playerHealth = GetComponent<Health>();

            playerHealth.OnHit(1, other.gameObject,this.gameObject);
        }
    }
}
