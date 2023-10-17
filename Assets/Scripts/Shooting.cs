using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private PlayerLightManager lightManager;

    void Start()
    {
        lightManager = GetComponent<PlayerLightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            lightManager.DecreaseLight();
            Shoot();
        }
    }
    void Shoot()
    {
        if (!lightManager.CanShoot())
        {
            return;
        }
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        Light2D bulletLight = bullet.GetComponent<Light2D>();
        bulletLight.intensity = lightManager.GetIntensity();
    }
}