using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    #region Public Fields
    public float health;
    #endregion

    #region Private Fields
    [SerializeField] private float maxHealth;
    [SerializeField] private float expAmount;
    [SerializeField] private Image healthIMG;
    [SerializeField] private Canvas healCanvas;
    private PlayerStats playerStats;
    private SpawnManager spawnManager;
    #endregion

    #region MonoBehaviour Callbacks
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

    #endregion

    #region Public Methods
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
    #endregion

    #region Private Methods

    private void AddExp()
    {
        playerStats.Exp(expAmount);
        spawnManager.KillCount(1);

    }
    #endregion
}
