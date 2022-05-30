using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackDamage : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float radius = 0.3f;
    [SerializeField] private float damageCount = 10f;
    private PlayerHealth playerHealth;
    private bool collided;
    #endregion

    #region MonoBehaviour Callbacks
    private void Update()
    {
        DamageThePlayer();
    }

    #endregion

    #region Public Methods


    #endregion


    #region Priate Methods

    private void DamageThePlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, playerMask);
        foreach (Collider c in hits)
        {
            playerHealth = c.gameObject.GetComponent<PlayerHealth>();
            collided = true;
        }
        if (collided)
        {
            playerHealth.TakeDamage(damageCount);
            enabled = false;
        }
    }

    #endregion
}
