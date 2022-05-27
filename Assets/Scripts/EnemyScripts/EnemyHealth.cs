using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthIMG;
    public Canvas healCanvas;
    public PlayerStats playerStats;
    public float expAmount;
    public SpawnManager spawnManager;
    
    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        health = maxHealth;
    }
    private void Update()
    {
        healCanvas.transform.LookAt(Camera.main.transform.position);
        healCanvas.transform.Rotate(0, 180, 0);
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        healthIMG.fillAmount = health / maxHealth;
        if(health <= 0)
        {
            health = 0;
            AddExp();
        }
    }

    void AddExp()
    {
        playerStats.Exp(expAmount);
        spawnManager.KillCount(1);

    }
}
