using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float damageCount = 5f;
    [SerializeField] private EnemyHealth enemyHealth;
    private bool collided;
    #endregion

    #region MonoBehaviour Callbacks
    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach(Collider c in hits)
        {
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageCount);
            collided = true;
            
        }
        if (collided)
        {
           // enemyHealth.TakeDamage(damageCount);
            enabled = false;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Mehtods

    #endregion
}
