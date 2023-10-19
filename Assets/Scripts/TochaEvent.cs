using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TochaEvent : MonoBehaviour
{
    public GameObject lightPrefab; // Reference to the prefab of the light you want to spawn.
    public GameObject tocha; // Reference to the prefab of the light you want to spawn.

    // This method is called when another object enters the trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has a specific tag or component.
        if (other.CompareTag("Projetil"))
        {
            // Spawn a light when the player enters the circle.
            SpawnLight();
            tocha.tag = "Tocha";
        }
    }
    void SpawnLight()
    {
        // Instantiate the lightPrefab at the current position of the circle.
        GameObject newLight = Instantiate(lightPrefab, transform.position, Quaternion.identity);
    }
}