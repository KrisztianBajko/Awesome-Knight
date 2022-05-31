using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveSpawnManager : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private Wave[] waveScriptableObjects;
    [SerializeField] private float currentTime;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeForNextBoss;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private int kills;
    [SerializeField] private Transform spawnPoint;
    private int waveIndex = -1; 
    private bool canSpawn;
    #endregion

    #region MonoBehaviour Callbacks
    void Update()
    {

        killText.text = "Kills " + kills.ToString();

        CheckForEnemies();

        if (canSpawn)
        {
            if (currentTime < 0)
            {
                if (waveIndex != waveScriptableObjects.Length)
                {
                    waveIndex++;
                }

                currentTime = timeBetweenWaves;
                StartCoroutine(SpawnEnemy());
               
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }

       
        
    }


    IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        for (int i = 0; i < waveScriptableObjects[waveIndex].numberOfEnemies; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint.position, -Vector3.up, out hit))
            {
                float randomPosx = Random.Range(-9, 9);
                float randomPosz = Random.Range(-12, 12);
                Vector3 location = new Vector3(hit.point.x + randomPosx, hit.point.y + .5f, hit.point.z + randomPosz);

                waveScriptableObjects[waveIndex].SpawnWave(location, 0);
            }
            yield return new WaitForSeconds(1f / waveScriptableObjects[waveIndex].spawnRate);
        }

        if(waveScriptableObjects[waveIndex].numberOfBosses != 0)
        {
            for (int i = 0; i < waveScriptableObjects[waveIndex].numberOfBosses; i++)
            {
                RaycastHit hit;
                if (Physics.Raycast(spawnPoint.position, -Vector3.up, out hit))
                {
                    waveScriptableObjects[waveIndex].SpawnWave(spawnPoint.position, 1);
                }
                yield return new WaitForSeconds(1f / waveScriptableObjects[waveIndex].spawnRate);
            }
        }
       

        yield break;
    }
    

    #endregion

    #region Public Methods
    public void CheckForEnemies()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            canSpawn = false;

        }
        else
        {
            canSpawn = true;

           
        }
    }
    public void KillCount(int k)
    {
        kills += k;
    }

    #endregion

    #region Private Methods

    #endregion

}
