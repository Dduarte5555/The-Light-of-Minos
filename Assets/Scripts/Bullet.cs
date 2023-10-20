using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Animator ani;
   
    
    public GameObject projetil;
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(projetil);
            Destroy(other.gameObject);

        }
    if (other.gameObject.CompareTag("Skeleton"))
        {
            Destroy(projetil);
            GameObject collidedObject = other.gameObject;
            ani = collidedObject.GetComponent<Animator>();
            ani.SetBool("IsDead",true);
            //Destroy(other.gameObject);
        }    
    }
    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.CompareTag("Parede"))
                {
                    Destroy(projetil);
                }
            }
    
}
