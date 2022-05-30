using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float damageDistance = 3f;
    private Transform playerTarget;
    private Animator animator;
    private bool finishedAttack = true;
    private PlayerHealth playerHealth;
    #endregion

    #region MonoBehaviour Callbacks
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
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private bool CheckIfAttacking()
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
    private void DealDamage(bool isAttacking)
    {
        if (isAttacking)
        {
            if(Vector3.Distance(transform.position, playerTarget.position)<= damageDistance)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    #endregion
}
