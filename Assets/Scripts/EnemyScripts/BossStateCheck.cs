using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    None,
    Idle,
    Pause,
    Attack,
    Death
}
public class BossStateCheck : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float distanceToTarget;
    private Transform playerTarget;
    private BossState bossState = BossState.None;
    private EnemyHealth bossHealth;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        bossHealth = GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        SetState();
    }

    #endregion

    #region Public Methods
    public BossState BossState
    {
        get { return bossState; }
        set { bossState = value; }
    }
    #endregion

    #region Private Methods
    private void SetState()
    {
        distanceToTarget = Vector3.Distance(transform.position, playerTarget.position);
        if(bossState != BossState.Death)
        {
            if(distanceToTarget > 3f && distanceToTarget <= 15f)
            {
                bossState = BossState.Pause;
            }else if(distanceToTarget > 15f)
            {
                bossState = BossState.Idle;
            }else if( distanceToTarget <= 3f)
            {
                bossState = BossState.Attack;
            }
            else
            {
                bossState = BossState.None;
            }
            if(bossHealth.health <= 0)
            {
                bossState = BossState.Death;
            }
        }
    }

    #endregion
   
}
