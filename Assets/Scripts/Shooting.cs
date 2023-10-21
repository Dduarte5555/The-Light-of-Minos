using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private PlayerLightManager lightManager;
    public Camera cam;
    public Rigidbody2D player;
    Animator ani;
    public DateTime currentTime;
    public Boolean hasShot;

    private float initialOuterRadius = 5f;

    Vector2 mousePos;

    void Start()
    {
        lightManager = GetComponent<PlayerLightManager>();
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && lightManager.CanShoot())
        {
            lightManager.DecreaseLight();
            Shoot();
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void Shoot()
    {
        // Start the attack animation and set the PlayerIsAttacking variable to true.
        ani.SetBool("PlayerIsAttacking", true);
        
    }

    public static float FindDegree(float x, float y)
    {
        float value = (float)((Mathf.Atan2(x, y) / Math.PI) * 180f);
        if (value < 0) value += 360f;

        return value;
    }

    public IEnumerator OnAttackAnimationFinished()
    {
        if (!hasShot) {
            hasShot = true;
            // Calculate the direction from the player.position to the mouse position (mousePos).
            Vector2 direction = (mousePos - player.position).normalized;

            // Calculate the position of the bullet spawn point, 1 meter from the player in the direction of the mouse.
            Vector3 bulletSpawnPosition = player.position + direction * 1f;

            // Get mouse angle
            Vector2 lookDir = mousePos - player.position;

            float angle = FindDegree(lookDir.x, lookDir.y);

            Quaternion rotation = Quaternion.Euler(0, 0, -angle);

            // Instantiate the bullet at the calculated position.
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Apply the force to the bullet.
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

            Light2D bulletLight = bullet.GetComponent<Light2D>();
            bulletLight.intensity = lightManager.GetIntensity();
            bulletLight.pointLightOuterRadius = bulletLight.intensity * initialOuterRadius;

            // Set the PlayerIsAttacking variable to false.
            ani.SetBool("PlayerIsAttacking", false);

            yield return new WaitForSeconds(0.1f);

            hasShot = false;
        }
        

    }
}
