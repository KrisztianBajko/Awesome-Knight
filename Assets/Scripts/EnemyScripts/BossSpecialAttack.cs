using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: make the boss stop attacking when the player dies
public class BossSpecialAttack : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private GameObject bossFire;
    [SerializeField] private GameObject bossMagic;
    private Transform playerTarget;

    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;   
    }


    #endregion


    #region Public Methods
    #endregion

    #region Private Methods
    private void BossSpell()
    {
        Vector3 temp = playerTarget.position;
        temp.y = 1.5f;
        Instantiate(bossMagic, temp, Quaternion.identity);
    }
    private void BossFireTornado()
    {
        Instantiate(bossFire, playerTarget.position, Quaternion.Euler(0f, Random.Range(0, 360f), 0f));
    }
    #endregion
}
