using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControler : MonoBehaviour
{
    #region Public Fields


    #endregion

    #region Private Fields
    [SerializeField] private float waitAttackTime = 1f;
    private Transform playerTarget;
    private BossStateCheck bossStateCheck;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool finishedAttacking = true;
    private float currentAttackTime;
    private PlayerMovement playerMovement;

    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        bossStateCheck = GetComponent<BossStateCheck>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (playerMovement.isDead)
        {
            return;
        }
        CheckForState();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void CheckForState()
    {
        if (finishedAttacking)
        {
            GetStateControl();
        }
        else
        {
            animator.SetInteger("Atk", 0);
            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttacking = true;
            }
        }
    }
    private void GetStateControl()
    {
        if(bossStateCheck.BossState == BossState.Death)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("Death", true);
            Destroy(gameObject, 3f);
        }
        else
        {
            if(bossStateCheck.BossState == BossState.Pause)
            {
                navMeshAgent.isStopped = false;
                animator.SetBool("Run", true);
                navMeshAgent.SetDestination(playerTarget.position);
            }else if(bossStateCheck.BossState == BossState.Attack)
            {
                animator.SetBool("Run", false);
                Vector3 targetPosition = new Vector3(playerTarget.position.x, transform.position.y, playerTarget.position.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);

                if(currentAttackTime >= waitAttackTime)
                {
                    int atkRange = Random.Range(1, 5);
                    animator.SetInteger("Atk", atkRange);
                    currentAttackTime = 0f;
                    finishedAttacking = false;
                }else
                {
                    animator.SetInteger("Atk", 0);
                    currentAttackTime += Time.deltaTime;
                }
            }
            else
            {
                animator.SetBool("Run", false);
                navMeshAgent.isStopped = true;
            }
        }
    }

    #endregion
}
