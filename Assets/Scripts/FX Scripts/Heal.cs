using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float healAmount = 20f;
    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(healAmount);
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
