using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    #region Public Fields
    public bool Shielded
    {
        get { return isShielded; }
        set { isShielded = value; }
    }
    #endregion

    #region Private Fields
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private bool isShielded;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI dieText;

    private Animator animator;
    private Image healthIMG;
    private PlayerMovement playerMovement;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthIMG = GameObject.Find("HealthIcon").GetComponent<Image>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    #endregion

    #region Public Methods
    public void DieText()
    {
        dieText.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
    public void TakeDamage(float dmg)
    {
        if (!isShielded)
        {

            currentHealth -= dmg;
            healthIMG.fillAmount = currentHealth / maxHealth;
            if(currentHealth <= 0f)
            {
                currentHealth = 0f;
                animator.SetBool("Death", true);
                gameManager.PlayerDie();
                playerMovement.IsDead = true;
                
            }
        }
    }
    public void HealPlayer(float healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthIMG.fillAmount = currentHealth / maxHealth;
    }

    #endregion

    #region Private Methods

    #endregion
}
