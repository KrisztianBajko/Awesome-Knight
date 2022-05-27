using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackDamage : MonoBehaviour
{
    public LayerMask playerMask;
    public float radius = 0.3f;
    public float damageCount = 10f;
    public PlayerHealth playerHealth;
    public bool collided;

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, playerMask);
        foreach(Collider c in hits)
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
}
