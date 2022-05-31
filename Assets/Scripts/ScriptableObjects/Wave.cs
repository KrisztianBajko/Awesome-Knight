using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Wave")]
public class Wave : ScriptableObject
{
    #region Public Fields
    public GameObject[] enemyPrefab;
    public int numberOfEnemies;
    public int numberOfBosses;
    public float spawnRate;
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    #endregion

    #region Private Fields

    #endregion

    #region Public methods

    public void SpawnWave(Vector3 position, int enemyIndex)
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab[enemyIndex], position, Quaternion.identity);

        spawnedEnemies.Add(spawnedEnemy);

    }

    #endregion

}
