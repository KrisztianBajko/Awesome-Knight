using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    public float damageCount = 5f;
    public EnemyHealth enemyHealth;
    public bool collided;

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
}
