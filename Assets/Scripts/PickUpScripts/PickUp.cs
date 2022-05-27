using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float manaAmount;
    public PlayerAttack playerAttack;
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
}
