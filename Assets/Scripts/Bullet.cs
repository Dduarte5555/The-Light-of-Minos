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
            // isColliding = true;
        }    
   }
}
