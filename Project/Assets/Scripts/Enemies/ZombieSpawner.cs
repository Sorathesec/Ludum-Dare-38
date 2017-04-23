using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class ZombiePool
{
    public string poolName;
    private float spawnRate = 0.0f;
    private GameObject prefab;
    private int pooledAmount;

    private GameObject[] objectPool;

    private Transform spawner;

    public ZombiePool(string name, GameObject prefab, int amount, float spawnRate, Transform spawner)
    {
        poolName = name;
        this.prefab = prefab;
        pooledAmount = amount;
        this.spawnRate = spawnRate;
        this.spawner = spawner;

        CreatePool();
    }

    private void CreatePool()
    {
        objectPool = new GameObject[pooledAmount];
        
        for (int i = 0; i < pooledAmount; i++)
        {
            objectPool[i] = GameObject.Instantiate(prefab) as GameObject;
            objectPool[i].transform.parent = spawner;
            objectPool[i].SetActive(false);
        }
    }

    public string GetName()
    {
        return poolName;
    }

    public float getSpawnRate()
    {
        return spawnRate;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            if (objectPool[i] != null &&
                !objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }
        return null;
    }

    private void ResetPool()
    {
        for (int i = 0; i < objectPool.Length; i++)
        {
            if (objectPool[i] != null &&
                objectPool[i].activeInHierarchy)
            {
                objectPool[i].SetActive(false);
            }
        }
    }
}

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private string[] poolNames;
    [SerializeField]
    protected int[] pooledAmounts;
    [SerializeField]
    protected GameObject[] objectPrefabs;
    [SerializeField]
    private float[] zombieSpawnRates;
    [SerializeField]
    private float spawnRate = 2.0f;
    [SerializeField]
    private int waveSize = 3;
    [SerializeField]
    private float spawnRateIncrease = 0.2f;
    [SerializeField]
    private float spawnRateIncreaseTimer = 20.0f;
    [SerializeField]
    private float minimumSpawnRate = 0.5f;
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject wormBoss;

    private ZombiePool[] pools;

    public static bool wormAlive = false;


    // Use this for initialization
    void Start()
    {
        pools = new ZombiePool[objectPrefabs.Length];
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new ZombiePool(poolNames[i], objectPrefabs[i], pooledAmounts[i], zombieSpawnRates[i], transform);
        }

        GameObject[] temp = GameObject.FindGameObjectsWithTag("ZombieSpawn");
        spawnPoints = new Transform[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            spawnPoints[i] = temp[i].transform;
        }
        Invoke("SpawnMultipleZombies", 3.0f);
        InvokeRepeating("IncreaseSpawnRate", spawnRateIncreaseTimer, spawnRateIncreaseTimer);
    }

    private void SpawnMultipleZombies()
    {
        for (int i = 0; i < waveSize; i++)
        {
            ChooseZombie();
        }
        Invoke("SpawnMultipleZombies", spawnRate);
    }

    private void ChooseZombie()
    {
        float rnd = Random.Range(0.0f, 1.0f);

        float totalSpawnRate = 0.0f;
        if(!wormAlive)
        {
            totalSpawnRate += 0.2f;
        }
        if(rnd < totalSpawnRate)
        {
            SpawnWorm();
        }
        for (int i = 0; i < pools.Length; i++)
        {
            totalSpawnRate += pools[i].getSpawnRate();
            if (rnd < totalSpawnRate)
            {
                TrySpawnZombie(pools[i].GetName());
            }
        }
    }

    private void SpawnWorm()
    {
        GameObject temp = Instantiate(wormBoss);
        int count = 0;
        while (count < 100)
        {
            int rnd = Random.Range(0, spawnPoints.Length);
            Vector2 prnt = spawnPoints[rnd].parent.GetComponent<WorldChunk>().GetChunkIndex();
            Vector2 player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().currentChunk;
            bool validX = (prnt.x > player.x + 1 || prnt.x < (player.x + 1) % 5) &&
                (prnt.x < player.x - 1 || (prnt.x > player.x && prnt.x < player.x + 4));
            bool validY = (prnt.y > player.y + 1 || prnt.y < (player.y + 1) % 5) &&
                (prnt.y < player.y - 1 || (prnt.y > player.y && prnt.y < player.y + 4));
            if (validX || validY)
            {
                temp.transform.position = spawnPoints[rnd].position;
                wormAlive = true;
                break;
            }
            count++;
        }
    }

    private void TrySpawnZombie(string zombieName)
    {
        int count = 0;
        while (count < 100)
        {
            int rnd = Random.Range(0, spawnPoints.Length);
            Vector2 prnt = spawnPoints[rnd].parent.GetComponent<WorldChunk>().GetChunkIndex();
            Vector2 player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().currentChunk;
            bool validX = (prnt.x > player.x + 1 || prnt.x < (player.x + 1) % 5) &&
                (prnt.x < player.x - 1 || (prnt.x > player.x && prnt.x < player.x + 4));
            bool validY = (prnt.y > player.y + 1 || prnt.y < (player.y + 1) % 5) &&
                (prnt.y < player.y - 1 || (prnt.y > player.y && prnt.y < player.y + 4));
            if (validX || validY)
            {
                SpawnZombie(spawnPoints[rnd].position, zombieName);
                break;
            }
            count++;
        }
    }
    private void SpawnZombie(Vector3 spawnPoint, string name)
    {
        GameObject zombie = null;
        for (int i = 0; i < pools.Length; i++)
        {
            if(pools[i].GetName() == name)
            {
                zombie = pools[i].GetPooledObject();
            }
        }

        if(zombie == null)
        {
            pools[pools.Length - 1].GetPooledObject();
        }

        if (zombie != null)
        {
            zombie.transform.position = spawnPoint;
            zombie.SetActive(true);
        }
    }

    private void IncreaseSpawnRate()
    {
        if (spawnRate <= minimumSpawnRate)
        {
            spawnRate = minimumSpawnRate;
        }
        else
        {
            spawnRate -= spawnRateIncrease;
        }
    }
}