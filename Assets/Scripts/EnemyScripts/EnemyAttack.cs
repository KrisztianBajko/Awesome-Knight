using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;
    public Transform playerTarget;
    public Animator animator;
    public bool finishedAttack = true;
    public float damageDistance = 3f;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        playerHealth = playerTarget.GetComponent<PlayerHealth>();
    }
    void Update()
    {
      
        if (finishedAttack)
        {
            DealDamage(CheckIfAttacking());
        }
        else
        {
            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttack = true;
            }
        }
    }

    bool CheckIfAttacking()
    {
        bool isAttacking = false;
        if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Atk1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Atk2"))
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                isAttacking = true;
                finishedAttack = false;
            }
        }
        return isAttacking;
    }
    void DealDamage(bool isAttacking)
    {
        if (isAttacking)
        {
            if(Vector3.Distance(transform.position, playerTarget.position)<= damageDistance)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
