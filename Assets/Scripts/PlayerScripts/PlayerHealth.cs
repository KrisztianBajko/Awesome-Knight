using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public bool isShielded;
    public Animator animator;
    public Image healthIMG;
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public TextMeshProUGUI dieText;
    public bool Shielded
    {
        get { return isShielded; }
        set { isShielded = value; }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthIMG = GameObject.Find("HealthIcon").GetComponent<Image>();
        playerMovement = GetComponent<PlayerMovement>();
    }
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
}
