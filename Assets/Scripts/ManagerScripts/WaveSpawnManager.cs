using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave waveScriptableObject;

    public bool canSpawn;
    public float currentTime;
    public float timeBetweenWaves;


    public float timeForNextBoss;
    public bool canSpawnBoss;


    public Transform spawnPoint;
    

    void Update()
    {
        CheckForEnemies();

        if (canSpawn)
        {
            if (currentTime <= 0)
            {

                currentTime = timeBetweenWaves;
                StartCoroutine(SpawnEnemy());

            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }

        if (canSpawnBoss)
        {
            if (timeForNextBoss <= 0)
            {
                timeForNextBoss = 30;
                SpawnEnemyBoss();
            }
        }
        
    }


    public void CheckForEnemies()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
            if (canSpawn)
            {
                if (currentTime < 0)
                {

                    currentTime = timeBetweenWaves;


                }
                else
                {
                    currentTime -= Time.deltaTime;
                }

            }

        }


    }

    IEnumerator SpawnEnemy()
    {
        canSpawn = false;


        for (int i = 0; i < waveScriptableObject.numberOfEnemies; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint.position, -Vector3.up, out hit))
            {
                float randomPosx = Random.Range(-10, 10);
                float randomPosz = Random.Range(-15, 15);
                Vector3 location = new Vector3(hit.point.x + randomPosx, hit.point.y + .5f, hit.point.z + randomPosz);

                waveScriptableObject.SpawnWave(location, 0);



            }
            yield return new WaitForSeconds(1f / waveScriptableObject.spawnRate);
        }

        yield break;
    }
    IEnumerator SpawnEnemyBoss()
    {
        canSpawnBoss = false;


        for (int i = 0; i < waveScriptableObject.numberOfEnemies; i++)
        {
            waveScriptableObject.SpawnWave(spawnPoint.position, 1);
            yield return new WaitForSeconds(1f / waveScriptableObject.spawnRate);
        }

        yield break;
    }
}
