using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float manaAmount;
    private PlayerAttack playerAttack;

    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        transform.Rotate(0f, 5f, 0f);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAttack.Mana(manaAmount);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
