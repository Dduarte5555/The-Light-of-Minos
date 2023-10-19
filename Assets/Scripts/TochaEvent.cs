using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TochaEvent : MonoBehaviour
{
    public GameObject lightPrefab; // Reference to the prefab of the light you want to spawn.
    public Light2D playerLight;
    private float initialOuterRadius = 5f;

    // This method is called when another object enters the trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has a specific tag or component.
        if (other.CompareTag("Projetil"))
        {
            // Spawn a light when the player enters the circle.
            SpawnLight();
        }
        if (other.CompareTag("Tocha"))
        {
            // Spawn a light when the player enters the circle.
            IncreaseLight();
        }
    }

    public void IncreaseLight()
    {
        playerLight.intensity = 1;
        playerLight.pointLightOuterRadius = playerLight.intensity * initialOuterRadius;
    }

    void SpawnLight()
    {
        // Instantiate the lightPrefab at the current position of the circle.
        GameObject newLight = Instantiate(lightPrefab, transform.position, Quaternion.identity);
    }
}
