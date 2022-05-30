using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float healAmount;
    private PlayerHealth playerHealth;

    #endregion

    #region MonoBehaviour Callbacks
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

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
