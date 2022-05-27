using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    public GameObject groundImpactSpawn, kickSpawn, fireTornadoSpawn, fireShieldSpawn;
    public GameObject groundImpactPrefab, kickPrefab, fireTornadoPrefab, fireShieldPrefab, healPrefab, thunderPrefab;
    public GameObject slashEffect;
    public GameManager gameManager;

    public void BasicAttack()
    {
        slashEffect.SetActive(true);
        
    }
    public void BasicAttackEnd()
    {
        slashEffect.SetActive(false);
    }
   
    public void GroundImpact()
    {
        gameManager.GroundImpactSound();
        Instantiate(groundImpactPrefab, groundImpactSpawn.transform.position, Quaternion.identity);
    }

    public void Kick()
    {
        gameManager.HitSound();
        Instantiate(kickPrefab, kickSpawn.transform.position, Quaternion.identity);
    }

    public void FireTornado()
    {
        gameManager.FireTornadoSound();
        Instantiate(fireTornadoPrefab, fireTornadoSpawn.transform.position, Quaternion.identity);
    }
    public void FireShield()
    {
        gameManager.FireShieldSound();
        GameObject fireSHD = Instantiate(fireShieldPrefab, fireShieldSpawn.transform.position, Quaternion.identity);
        fireSHD.transform.SetParent(transform);
    }
    public void Heal()
    {
        gameManager.HealSound();
        Vector3 tempPos = transform.position;
        tempPos.y += 2f;
        GameObject heal = Instantiate(healPrefab, tempPos, Quaternion.identity);
        heal.transform.SetParent(transform);
    }
    public void ThunderAttack()
    {
        for(int i = 0;i < 9; i++)
        {
            Vector3 pos = Vector3.zero;
            if(i == 0)
            {
                pos = new Vector3(transform.position.x - 4f, transform.position.y + -1f, transform.position.z);
            }else if(i == 1)
            {
                pos = new Vector3(transform.position.x + 4f, transform.position.y + -1f, transform.position.z);
            }
            else if (i == 2)
            {
                pos = new Vector3(transform.position.x, transform.position.y + -1f, transform.position.z -4f);
            }
            else if (i == 3)
            {
                pos = new Vector3(transform.position.x, transform.position.y + -1f, transform.position.z + 4f);
            }
            else if (i == 4)
            {
                pos = new Vector3(transform.position.x +2.5f, transform.position.y + -1f, transform.position.z +2.5f);
            }
            else if (i == 5)
            {
                pos = new Vector3(transform.position.x - 2.5f, transform.position.y + -1f, transform.position.z + 2.5f);
            }
            else if (i == 6)
            {
                pos = new Vector3(transform.position.x - 2.5f, transform.position.y + -1f, transform.position.z - 2.5f);
            }
            else if (i == 7)
            {
                pos = new Vector3(transform.position.x + 2.5f, transform.position.y + -1f, transform.position.z + 2.5f);
            }
            else if(i == 8)
            {
                pos = new Vector3(transform.position.x + 2.5f, transform.position.y + -1f, transform.position.z - 2.5f);
            }
            Instantiate(thunderPrefab, pos, Quaternion.identity);
            gameManager.ThunderSound();
        }
    }
   
}
