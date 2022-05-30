using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornado : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float radius = .5f;
    [SerializeField] private float damageCount = 10f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private GameObject fireExplosion;

    private EnemyHealth enemyHealth;
    private bool collided;
    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }
    private void Update()
    {
        Move();
        CheckForDamage();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
    private void CheckForDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider c in hits)
        {
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;

        }
        if (collided)
        {
            enemyHealth.TakeDamage(damageCount);
            Vector3 temp = transform.position;
            temp.y += 1f;
            Instantiate(fireExplosion, temp, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    #endregion
}
