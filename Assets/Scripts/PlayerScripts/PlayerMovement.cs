using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: check if grounded and apply gravity
public class PlayerMovement : MonoBehaviour
{

    #region Public Fields
    public bool isDead;
    public bool canMove;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }
    #endregion

    #region Private Fields
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float playerToPointDistance;
    [SerializeField] private float attackRange;
    [SerializeField] private float gravity;
    [SerializeField] private float height;

    private Vector3 velocity;
    private Vector3 targetPosition = Vector3.zero;
    private Vector3 playerMove = Vector3.zero;
    private bool finishedMovement;
    private bool isGrounded = true;
    private Animator animator;
    private CharacterController cc;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (!IsDead)
        {
            MoveThePlayer();
            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
            CalculateHeight();
            CheckIfFinishedMovement();
            cc.Move(playerMove);
            
            
        }

       
    }
    #endregion

    #region Public Methods
    public bool FinishedMovement
    {
        get
        {
            return finishedMovement;
        }
        set
        {
            finishedMovement = value;
        }
    }
    public Vector3 TargetPosition
    {
        get
        {
            return targetPosition;
        }
        set
        {
            targetPosition = value;
        }
    }
    #endregion

    #region Private Methods
   private void CalculateHeight()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
       
     
    }
   private void CheckIfFinishedMovement()
    {
        if (!finishedMovement)
        {
            if(!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Stand") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                finishedMovement = true;
            }
            else
            {
                MoveThePlayer();
                playerMove.y = height * Time.deltaTime;
            }

        }
        
    }
   private void MoveThePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    playerToPointDistance = Vector3.Distance(transform.position, hit.point);
                    if(playerToPointDistance >= .2f)
                    {
                        canMove = true;
                        targetPosition = hit.point;
                        
                    }
                }
            
            }
            
            
        }
        if (canMove)
        {
            animator.SetFloat("Walk", 1f);

            
                Vector3 targetTempPos = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

                Quaternion quaternion = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetTempPos - transform.position), 30f * Time.deltaTime);
                transform.rotation = quaternion;

                playerMove = transform.forward * moveSpeed * Time.deltaTime;
                if (Vector3.Distance(transform.position, targetPosition) <= .15f)
                {
                    canMove = false;
                    playerMove.Set(0f, 0f, 0f);
                    animator.SetFloat("Walk", 0f);
                }

            



        }
    }

    #endregion

}
