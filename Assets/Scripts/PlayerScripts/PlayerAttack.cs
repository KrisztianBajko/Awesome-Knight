using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private Image CDImage1;
    [SerializeField] private Image CDImage2;
    [SerializeField] private Image CDImage3;
    [SerializeField] private Image CDImage4;
    [SerializeField] private Image CDImage5;
    [SerializeField] private Image CDImage6;
    [SerializeField] private Image[] reqImagies;
    [SerializeField] private float maxMana;
    [SerializeField] private float currentMana;
    [SerializeField] private Image manaIcon;
    [SerializeField] private int[] fadeImages = new[] { 0, 0, 0, 0, 0, 0 };

    private bool canAttack = true;
    private Animator animator;
    private PlayerMovement playerMovement;
    private PlayerStats playerStats;

    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        currentMana = maxMana;
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.IsDead == true)
        {
            return;
        }
        if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
        DisplayMana();
        CheckToFade();
        CheckToInput();
        CheckForLevel();
    }

    #endregion

    #region Public Methods
    public void Mana(float manaAmount)
    {
        currentMana += manaAmount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        manaIcon.fillAmount = currentMana / maxMana;
    }
    #endregion

    #region Private Methods
    private void CheckToInput()
    {
        if (animator.GetInteger("Atk") == 0)
        {
            playerMovement.FinishedMovement = false;
            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMovement.FinishedMovement = true;
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (playerMovement.FinishedMovement && canAttack)
            {

                animator.SetInteger("Atk", 7);

                playerMovement.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (playerStats.level < 2)
            {

                //play not enough mana sound
            }
            else
            {

                float manaCost = 15f;
                if (playerMovement.FinishedMovement && fadeImages[0] != 1 && canAttack && currentMana >= manaCost)
                {
                    CheckForMana(manaCost);
                    fadeImages[0] = 1;
                    animator.SetInteger("Atk", 1);

                    playerMovement.TargetPosition = transform.position;
                    RemoveCursorPoint();
                }
                else
                {
                    if (currentMana < manaCost)
                    {

                    }

                }
            }


        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerStats.level < 3)
            {
                //play not enough mana sound
            }
            else
            {
                float manaCost = 10;
                if (playerMovement.FinishedMovement && fadeImages[1] != 1 && canAttack && currentMana >= manaCost)
                {
                    CheckForMana(manaCost);
                    fadeImages[1] = 1;
                    animator.SetInteger("Atk", 2);

                    playerMovement.TargetPosition = transform.position;
                    RemoveCursorPoint();
                }
                else
                {
                    if (currentMana < manaCost)
                    {

                    }

                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerStats.level < 5)
            {
                //play not enough mana sound
            }
            else
            {
                float manaCost = 40f;
                if (playerMovement.FinishedMovement && fadeImages[2] != 1 && canAttack && currentMana >= manaCost)
                {
                    CheckForMana(manaCost);
                    fadeImages[2] = 1;
                    animator.SetInteger("Atk", 3);
                    playerMovement.TargetPosition = transform.position;
                    RemoveCursorPoint();
                }
                else
                {
                    if (currentMana < manaCost)
                    {

                    }

                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (playerStats.level < 9)
            {
                //play not enough mana sound
            }
            else
            {
                float manaCost = 100f;
                if (playerMovement.FinishedMovement && fadeImages[3] != 1 && canAttack && currentMana >= manaCost)
                {
                    CheckForMana(manaCost);
                    fadeImages[3] = 1;
                    animator.SetInteger("Atk", 4);
                    playerMovement.TargetPosition = transform.position;
                    RemoveCursorPoint();
                }
                else
                {
                    if (currentMana < manaCost)
                    {

                    }

                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (playerStats.level < 12)
            {
                //play not enough mana sound
            }
            else
            {
                float manaCost = 50f;
                if (playerMovement.FinishedMovement && fadeImages[4] != 1 && canAttack && currentMana >= manaCost)
                {
                    CheckForMana(manaCost);
                    fadeImages[4] = 1;
                    animator.SetInteger("Atk", 5);
                    playerMovement.TargetPosition = transform.position;
                    RemoveCursorPoint();
                }
                else
                {
                    if (currentMana < manaCost)
                    {

                    }

                }
            }

        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (playerStats.level < 15)
            {
                //play not enough mana sound
            }
            else
            {
                float manaCost = 120f;
                if (playerMovement.FinishedMovement && fadeImages[5] != 1 && canAttack && currentMana >= manaCost)
                {
                    CheckForMana(manaCost);
                    fadeImages[5] = 1;
                    animator.SetInteger("Atk", 6);
                    playerMovement.TargetPosition = transform.position;
                    RemoveCursorPoint();
                }
                else
                {
                    if (currentMana < manaCost)
                    {

                    }

                }
            }

        }
        else
        {
            animator.SetInteger("Atk", 0);
        }

        if (!playerMovement.canMove)
        {
            Vector3 targetPos = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos - transform.position), 15f * Time.deltaTime);
        }
    }
    private void CheckForMana(float manaCost)
    {
        if (currentMana >= manaCost)
        {
            currentMana -= manaCost;
        }


    }
    private void CheckForLevel()
    {
        switch (playerStats.level)
        {
            case 2:
                reqImagies[0].gameObject.SetActive(false);
                break;
            case 3:
                reqImagies[1].gameObject.SetActive(false);
                break;
            case 5:
                reqImagies[2].gameObject.SetActive(false);
                break;
            case 9:
                reqImagies[3].gameObject.SetActive(false);
                break;
            case 12:
                reqImagies[4].gameObject.SetActive(false);
                break;
            case 15:
                reqImagies[5].gameObject.SetActive(false);
                break;

        }
    }
    private void DisplayMana()
    {
        manaIcon.fillAmount = currentMana / maxMana;
    }
    private void CheckToFade()
    {
        if (fadeImages[0] == 1)
        {
            if (FadeAndWait(CDImage1, .25f))
            {
                fadeImages[0] = 0;
            }
        }
        if (fadeImages[1] == 1)
        {
            if (FadeAndWait(CDImage2, .3f))
            {
                fadeImages[1] = 0;
            }
        }
        if (fadeImages[2] == 1)
        {
            if (FadeAndWait(CDImage3, .1f))
            {
                fadeImages[2] = 0;
            }
        }
        if (fadeImages[3] == 1)
        {
            if (FadeAndWait(CDImage4, .03f))
            {
                fadeImages[3] = 0;
            }
        }
        if (fadeImages[4] == 1)
        {
            if (FadeAndWait(CDImage5, .01f))
            {
                fadeImages[4] = 0;
            }
        }
        if (fadeImages[5] == 1)
        {
            if (FadeAndWait(CDImage6, .005f))
            {
                fadeImages[5] = 0;
            }
        }
    }
    private bool FadeAndWait(Image fadeImg, float fadeTime)
    {
        bool faded = false;
        if (fadeImg == null)
        {
            return faded;
        }
        if (!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1;
        }
        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0f)
        {
            fadeImg.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }
    private void RemoveCursorPoint()
    {
        GameObject cursoObj = GameObject.FindGameObjectWithTag("Cursor");
        if (cursoObj)
        {
            Destroy(cursoObj);
        }

    }
    #endregion

}
