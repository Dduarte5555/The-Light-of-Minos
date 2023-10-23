using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public AudioSource audioSourceSkeletonWalking;
    public AudioSource audioSourceSkeletonAttack;
    public AudioSource audioSourceFireHit;
    public SpriteRenderer enemySprite;

    public string enemyType;

    public bool hasAttacked;

    Animator ani;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ani = this.GetComponent<Animator>();
        
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(ani.GetBool("IsDead")){
            direction = new Vector3(0f, 0f, 0f);
        }
        direction.Normalize();
        
        ani.SetFloat("Angle", angle);

        var dis = Vector3.Distance(player.position , transform.position);
        if (dis < 6){
            ani.SetBool("IsAttacking",true);
            //direction = new Vector3(0, 0, 0);
        }

        //if (ani.GetBool("IsAttacking"))
        //{
        //    if (enemyType == "skeleton")
        //    {
        //        audioSourceSkeletonWalking.Stop();
        //    }
        //    direction = new Vector3(0, 0, 0);
        //}

        if (enemyType == "skeleton")
        {
            audioSourceSkeletonWalking.Stop();
        }

        movement = direction;
    }

    public void EnemyGotHit()
    {
        audioSourceFireHit.Play();
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }
    
    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void AttackEnded()
    {
        ani.SetBool("IsAttacking", false);
        audioSourceSkeletonWalking.Play();
    }

    public IEnumerator SkeletonAttackAudio()
    {
        if (!hasAttacked)
        {
            hasAttacked = true;
            audioSourceSkeletonAttack.Play();

            var dis = Vector3.Distance(player.position, transform.position);
            if (dis < 5.5)
            {
                Health playerHealth = player.GetComponent<Health>();

                playerHealth.OnHit(1, transform.gameObject, player.gameObject);
                PlayerMovement pmov = player.GetComponent<PlayerMovement>();

                StartCoroutine(pmov.FlashDamage());

                pmov.audioSourcePlayerDamage.Play();
            }

            yield return new WaitForSeconds(1);

            hasAttacked = false;


        }
    }


}
