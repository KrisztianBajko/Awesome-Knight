using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    private PlayerHealth playerHealth;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    private void OnEnable()
    {
        playerHealth.Shielded = true;
    }
    private void OnDisable()
    {
        playerHealth.Shielded = false;
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
