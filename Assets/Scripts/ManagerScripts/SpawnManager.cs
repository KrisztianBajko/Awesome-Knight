using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnManager : MonoBehaviour
{
    #region Public Fields

    #endregion
    

    #region Private Fields
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeBetwennBosses;
    [SerializeField] private float spawnRate;
    [SerializeField] private int enemyCount;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] bossSpawnPoint;
    [SerializeField] private GameObject boss;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private int kills;
    [SerializeField] private int bossCount;
    [SerializeField] private int maxBossCount;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float timer;
    [SerializeField] private float currentTime;
    [SerializeField] private float timeForBoss;

    private bool canSpawn = true;
    private bool canSpawnBoss = true;
    public PlayerMovement playerMovement;

    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       
    }

    void Update()
    {
        
        killText.text = "Kills " + kills.ToString();
        if (playerMovement.isDead)
        {
            return;
        }
        if (currentTime <= 0)
        {
            canSpawn = true;
            currentTime = timeBetweenWaves;
            if (canSpawn)
            {
                StartCoroutine(SpawnEnemy());
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

        if (timeForBoss <= 0)
        {
            canSpawnBoss = true;
            timeForBoss = timeBetwennBosses;
            if (canSpawnBoss)
            {
                StartCoroutine(SpawnBoss());
            }
        }
        else
        {
            timeForBoss -= Time.deltaTime;
        }

        timer += Time.deltaTime;

        if(timer > 120)
        {
            enemyCount = 2;
            bossCount = 2;
        }
        else if(timer > 360)
        {
            enemyCount = 6;
            bossCount = 3;
        }
        else if (timer > 480)
        {
            enemyCount = 10;
            bossCount = 4;
        }
        else if (timer > 660)
        {
            enemyCount = 15;
            bossCount = 5;
        }
        else if (timer > 840)
        {
            enemyCount = 25;
            bossCount = 6;
        }
        else if (timer > 920)
        {
            enemyCount = 35;
            bossCount = 7;
        }


    }

  
    IEnumerator SpawnEnemy()
    {
        canSpawn = false;
      

        for (int i = 0; i < enemyCount; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint.transform.position, -Vector3.up, out hit))
            {
                float randomPosx = Random.Range(-10, 10);
                float randomPosz = Random.Range(-15, 15);
                Vector3 location = new Vector3(hit.point.x + randomPosx, hit.point.y + .5f, hit.point.z + randomPosz);

                Instantiate(enemy, location, transform.rotation);



            }
            yield return new WaitForSeconds(1f / spawnRate);
        }

        yield break;
    }
    IEnumerator SpawnBoss()
    {
        canSpawn = false;
      
        
        for(int i = 0; i < bossCount; i++)
        {
            int radomSpawnPoint = Random.Range(0, bossSpawnPoint.Length);
            RaycastHit hit;
            if (Physics.Raycast(bossSpawnPoint[radomSpawnPoint].transform.position, -Vector3.up, out hit))
            {
                float randomX = Random.Range(-5, 5);
                float randomZ = Random.Range(-2, 2);
                Vector3 location = new Vector3(hit.point.x + randomX, hit.point.y + .5f, hit.point.z + randomZ);
                Instantiate(boss, location, transform.rotation);



            }
            yield return new WaitForSeconds(1f / spawnRate);
        }
       
        

        yield break;
    }
    #endregion

    #region Public Methods
    public void KillCount(int k)
    {
        kills += k;
    }

    #endregion

    #region Private Methods

    #endregion
}
