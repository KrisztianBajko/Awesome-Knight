using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Wave")]
public class Wave : ScriptableObject
{
    public GameObject[] enemyPrefab;
    public int numberOfEnemies;
    public int numberOfBosses;
    public float spawnRate;


    public void SpawnWave(Vector3 position, int enemyIndex)
    {
        Instantiate(enemyPrefab[enemyIndex], position, Quaternion.identity);
    }




  
}
