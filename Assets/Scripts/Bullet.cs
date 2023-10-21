using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projetil;
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Parede"))
        {
            Destroy(projetil);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            GameObject objeto = other.gameObject; 
            if (enemyHealth != null)
            {
                enemyHealth.OnHit(1, projetil,objeto);
            }

            Destroy(projetil);
        }
    }
    
}
