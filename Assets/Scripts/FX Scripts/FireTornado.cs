using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornado : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = .5f;
    public float damageCount = 10f;
    public GameObject fireExplosion;
    public EnemyHealth enemyHealth;
    public bool collided;
    public float speed = 3f;

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
}
