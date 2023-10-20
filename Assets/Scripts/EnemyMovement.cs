using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
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
            direction = new Vector3(0f,0f,0f);

        }
        direction.Normalize();
        movement = direction;
        ani.SetFloat("Angle", angle);

        var dis = Vector3.Distance(player.position , transform.position);
        if (dis < 3){
            ani.SetBool("IsAttacking",true);
        }
        else{
            ani.SetBool("IsAttacking",false);
        }
        
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
