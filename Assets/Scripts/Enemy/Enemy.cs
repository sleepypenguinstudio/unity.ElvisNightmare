using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float attackRange = 5;
    public float speed = 3;
    public int health;
    public int maxHealth;
    public Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.gameOver)
        {
            animator.enabled= false;
            this.enabled = false;
        }
        float distance = Vector3.Distance(transform.position, target.position);

        if(currentState == "IdleState")
        {
            if (distance < chaseRange)
            {
                currentState = "ChaseState";
            }           
        }
        else if (currentState == "ChaseState")
        {
            //play the run animation
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if(distance< attackRange)
            {
                currentState = "AttackState";
            }

            if (target.position.x < transform.position.x)
            {
                //move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                //move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                
            }
        }
        else if (currentState == "AttackState")
        {
            animator.SetBool("isAttacking", true);
            if (distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        currentState = "ChaseState";
        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play death animation
        animator.SetTrigger("isDead");
        //disable script and collider
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled= false;
    }
}
