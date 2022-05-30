using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAtack : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float damageCount = 5f;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private GameManager gameManager;
    #endregion

    #region MonoBehaviour Callbacks

    #endregion

    #region Public Methods
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

    #endregion

    #region Private Methods

    #endregion
}
