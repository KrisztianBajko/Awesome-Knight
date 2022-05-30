using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    Idle,
    Walk,
    Run,
    Pause,
    Goback,
    Attack,
    Death
}
public class EnemyController : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float attackDistance = 3f;
    [SerializeField] private float alertAttackDistance = 12f;
    [SerializeField] private float followDistance = 25f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float waitAttackTime = 1f;
    [SerializeField] private GameObject[] pickUps;

    private float enemyToPlayerDistance;
    private EnemyState enemyCurrentState = EnemyState.Idle;
    private EnemyState enemyLastState = EnemyState.Idle;
    private Transform playerTarget;
    private Vector3 initialPosition;
    private CharacterController CC;
    private Vector3 whereToMove = Vector3.zero;
    private float currentAttackTime;
    private Animator animator;
    private bool finishedAnimation = true;
    private bool finishedMovement = true;
    private NavMeshAgent navAgent;
    private Vector3 whereToNavigate;
    private EnemyHealth enemyHealth;
    private PlayerMovement playerMovement;
    private bool isDead = false;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        CC = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        initialPosition = transform.position;
        whereToNavigate = transform.position;
    }
    void Update()
    {
        if(playerMovement.IsDead == true)
        {
            enabled = false;
            animator.enabled = false;
        }
        // if health is <= 0 will set the stat to death
        if(enemyHealth.health <= 0)
        {
            enemyCurrentState = EnemyState.Death;
        }
        if(enemyCurrentState != EnemyState.Death)
        {
            enemyCurrentState = SetEnemyState(enemyCurrentState, enemyLastState, enemyToPlayerDistance);

            if (finishedMovement)
            {
                GetStateControl(enemyCurrentState);
            }
            else
            {
                if(!animator.IsInTransition(0)&& animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    finishedMovement = true;
                }else if(!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsTag("Atk1") || animator.GetCurrentAnimatorStateInfo(0).IsTag("Atk2")){
                    animator.SetInteger("Atk", 0);
                }
            }
        }
        else
        {
            animator.SetBool("Death", true);
            CC.enabled = false;
            navAgent.enabled = false;
            if(!animator.IsInTransition(0)&& animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
            {
                Destroy(gameObject, 2f);
                if (!isDead)
                {
                    DropItem();
                    isDead = true;
                }
            }
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void DropItem()
    {
        if(Random.value <= 0.35f)
        {
            int index = Random.Range(0, pickUps.Length);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Instantiate(pickUps[index], pos, Quaternion.identity);
        }
    }
    private EnemyState SetEnemyState(EnemyState curState, EnemyState lastState, float enemyToPlayerDistance)
    {
        enemyToPlayerDistance = Vector3.Distance(transform.position, playerTarget.position);
        float distance = Vector3.Distance(initialPosition, transform.position);
        if(distance > followDistance)
        {
            lastState = curState;
            curState = EnemyState.Goback;

        }else if(enemyToPlayerDistance <= attackDistance)
        {
            lastState = curState;
            curState = EnemyState.Attack;
        }else if(enemyToPlayerDistance >= alertAttackDistance && lastState == EnemyState.Pause || lastState == EnemyState.Attack)
        {
            lastState = curState;
            curState = EnemyState.Pause;
        }else if(enemyToPlayerDistance <= alertAttackDistance && enemyToPlayerDistance > attackDistance)
        {
            if(curState != EnemyState.Goback || lastState == EnemyState.Walk)
            {
                lastState = curState;
                curState = EnemyState.Pause;
            }
        }else if(enemyToPlayerDistance > alertAttackDistance && lastState != EnemyState.Goback && lastState != EnemyState.Pause)
        {
            lastState = curState;
            curState = EnemyState.Walk;
        }
        return curState;
    }
    private void GetStateControl(EnemyState curState)
    {
        if(curState == EnemyState.Run || curState == EnemyState.Pause)
        {
            if(curState != EnemyState.Attack)
            {
                Vector3 targetPosition = new Vector3(playerTarget.position.x, playerTarget.position.y, playerTarget.position.z);

               if(Vector3.Distance(transform.position, targetPosition) >= 2.1f)
                {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", true);

                    navAgent.SetDestination(targetPosition);
                }
            }
        }else if(curState == EnemyState.Attack)
        {
            animator.SetBool("Run", false);
            whereToMove.Set(0f, 0f, 0f);

            navAgent.SetDestination(transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerTarget.position - transform.position), 5f * Time.deltaTime);

            if(currentAttackTime >= waitAttackTime)
            {
                int atkRange = Random.Range(1, 3);
                animator.SetInteger("Atk", atkRange);
                finishedAnimation = false;
                currentAttackTime = 0f;
            }
            else
            {
                currentAttackTime += Time.deltaTime;
                animator.SetInteger("Atk", 0);
            }

        }else if(curState == EnemyState.Goback)
        {
            animator.SetBool("Run", true);
            Vector3 targetPos = new Vector3(initialPosition.x, transform.position.y, initialPosition.z);
            navAgent.SetDestination(targetPos);
            if (Vector3.Distance(targetPos,transform.position) <= 3f)
            {
                enemyLastState = curState;
                enemyCurrentState = EnemyState.Walk;

            }
          
        }
        else if(curState == EnemyState.Walk)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);

            if(Vector3.Distance(transform.position, whereToNavigate) <= 2f)
            {
                whereToNavigate.x = Random.Range(initialPosition.x - 25f, initialPosition.x + 25);
                whereToNavigate.z = Random.Range(initialPosition.z - 25f, initialPosition.z + 25f);
            }
            else
            {
                navAgent.SetDestination(whereToNavigate);
            }
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
            whereToMove.Set(0f, 0f, 0f);
            navAgent.isStopped = true;
        }
    }

    #endregion
}
