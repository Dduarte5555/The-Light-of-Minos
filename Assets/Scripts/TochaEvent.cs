using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TochaEvent : MonoBehaviour
{
    // public GameObject lightPrefab; // Reference to the prefab of the light you want to spawn.
    public GameObject tocha; // Reference to the prefab of the light you want to spawn.
    public Light2D Light;
    AudioSource aud;
    Animator ani;
    private bool hasLight;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        ani = this.GetComponent<Animator>();
        hasLight = false;
    }


    // This method is called when another object enters the trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has a specific tag or component.
        if (other.CompareTag("Projetil"))
        {
            // Spawn a light when the bullet enters the circle.
            SpawnLight();
            Destroy(other.gameObject);
        }
    }
    void SpawnLight()
    {
        // Instantiate the lightPrefab at the current position of the circle.
        // GameObject newLight = Instantiate(lightPrefab, transform.position, Quaternion.identity);
        Light.intensity = 1;
        aud.Play();
        ani.SetBool("OnFire", true);
        hasLight = true;
    }

    public void DisableLight()
    {
        Light.intensity = 0;
        ani.SetBool("OnFire", false);
        hasLight = false;
    }

    public bool HasLight()
    {
        return hasLight;
    }
}