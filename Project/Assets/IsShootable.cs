using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsShootable : MonoBehaviour {

    public int health = 10;
    public AudioClip deathClip;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;
    public GameObject zombie;

    AudioSource enemyAudio;
    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;
    public GameObject weapon;

    public void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
            GetComponent<SpriteRenderer>().enabled = false;
            if (weapon != null)
            {
                Destroy(weapon);
            }
            if (circleCollider != null)
            {
                circleCollider.isTrigger = true;
            }
            if (boxCollider != null)
            {
                boxCollider.isTrigger = true;
            }
            gameObject.tag = "Dead";
            if (explosionPrefab != null)
            {
                Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                      transform.eulerAngles.y,
                                                      transform.eulerAngles.z + adjustExplosionAngle);
                Instantiate(explosionPrefab, transform.position, newRot);
            }

            Destroy(gameObject, 2f);
        }

    }
}
