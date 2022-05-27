using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAtack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    public float damageCount = 5f;
    public EnemyHealth enemyHealth;
    public GameObject attackPoint;
    public GameManager gameManager;
   
    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(attackPoint.transform.position, radius, enemyLayer);

        foreach (Collider c in hits)
        {
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageCount);
            gameManager.BasicAttackSound();
        }
    }
}
