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
                enemyHealth.OnHit(1, projetil, objeto);
            }

            EnemyMovement enemyMovement = other.gameObject.GetComponent<EnemyMovement>();

            enemyMovement.EnemyGotHit();

            SpriteRenderer enemySprite = other.gameObject.GetComponent<SpriteRenderer>();
            if (enemySprite != null)
            {
                StartCoroutine(FlashDamage(enemySprite));
            }
        }
    }

    public IEnumerator FlashDamage(SpriteRenderer enemySprite)
    {
        projetil.GetComponent<Renderer>().enabled = false;
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.white;
       
        Destroy(projetil);
    }
}
