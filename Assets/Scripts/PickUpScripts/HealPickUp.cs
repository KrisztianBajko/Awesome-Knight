using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour
{
    public float healAmount;
    public PlayerHealth playerHealth;
    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    
    private void Update()
    {
        transform.Rotate(0f, 5f, 0f);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
