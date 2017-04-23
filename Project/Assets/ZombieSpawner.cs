using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class ZombieSpawner : BasicPoolManager
{
    [SerializeField]
    private float spawnRate = 2.0f;
    [SerializeField]
    private int waveSize = 3;
    private Transform[] spawnPoints;


    // Use this for initialization
    void Start()
    {
        CreatePool();
        GameObject[] temp = GameObject.FindGameObjectsWithTag("ZombieSpawn");
        spawnPoints = new Transform[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            spawnPoints[i] = temp[i].transform;
        }
        InvokeRepeating("SpawnMultipleZombies", 3.0f, spawnRate);
    }

    private void SpawnMultipleZombies()
    {
        for(int i = 0; i < waveSize; i++)
        {
            TrySpawnZombie();
        }
    }

    private void TrySpawnZombie()
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
                SpawnZombie(spawnPoints[rnd].position);
                break;
            }
            count++;
        }
    }
    private void SpawnZombie(Vector3 spawnPoint)
    {
        GameObject zombie = GetPooledItem();

        if (zombie != null)
        {
            zombie.transform.position = spawnPoint;
            zombie.SetActive(true);
        }
    }
}