using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterZombie : ZombieHealth
{
    [SerializeField]
    private GameObject splitPrefab;
    [SerializeField]
    private int numOfSplits;
    [SerializeField]
    private Vector2 spawnRange;

    private GameObject[] splits;

    void Start()
    {
        splits = new GameObject[numOfSplits];
        for(int i = 0; i < numOfSplits; i++)
        {
            splits[i] = Instantiate(splitPrefab);
            splits[i].SetActive(false);
        }
    }

    protected override void Die()
    {
        if (deathClip != null &&
            enemyAudio != null)
        {
            enemyAudio.PlayOneShot(deathClip);
        }

        renderer.enabled = false;
        attack.enabled = false;
        collider.enabled = false;
        trigger.enabled = false;

        foreach(GameObject obj in splits)
        {
            float rndX = Random.Range(-spawnRange.x, spawnRange.x);
            float rndY = Random.Range(-spawnRange.y, spawnRange.y);
            obj.transform.position = new Vector2(transform.position.x + rndX, transform.position.y + rndY);
            obj.SetActive(true);
        }

        Invoke("Disable", 0.5f);
    }
}
