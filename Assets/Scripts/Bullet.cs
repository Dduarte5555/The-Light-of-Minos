using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projetil;
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(projetil);
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.CompareTag("Parede"))
                {
                    Destroy(projetil);
                }
            }
    
}
