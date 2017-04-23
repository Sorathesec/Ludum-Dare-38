using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsShootable : MonoBehaviour
{
    public int health = 10;
    public AudioClip deathClip;
    //public GameObject explosionPrefab;
    //public float adjustExplosionAngle = 0.0f;

    AudioSource enemyAudio;

    public void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (enemyAudio != null)
        {
            enemyAudio.Play();
        }
        if (health <= 0)
        {
            if (deathClip != null)
            {
                enemyAudio.clip = deathClip;
            }
            if (enemyAudio != null)
            {
                enemyAudio.Play();
            }

            gameObject.SetActive(false);
        }
    }
}
