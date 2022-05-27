using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: make the boss stop attacking when the player dies
public class BossSpecialAttack : MonoBehaviour
{
    public GameObject bossFire;
    public GameObject bossMagic;
    public Transform playerTarget;
    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    void BossSpell()
    {
        Vector3 temp = playerTarget.position;
        temp.y = 1.5f;
        Instantiate(bossMagic, temp, Quaternion.identity);
    }
    void BossFireTornado()
    {
        Instantiate(bossFire, playerTarget.position, Quaternion.Euler(0f, Random.Range(0, 360f), 0f));
    }

}
