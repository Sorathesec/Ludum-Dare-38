using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsShootable : MonoBehaviour
{
    public int health = 10;
    public AudioClip deathClip;
    public AudioClip damageClip;
    //public GameObject explosionPrefab;
    //public float adjustExplosionAngle = 0.0f;

    AudioSource enemyAudio;
    SpriteRenderer renderer;
    ZombieAttack attack;
    CircleCollider2D collider;

    public void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        attack = GetComponent<ZombieAttack>();
        collider = GetComponent<CircleCollider2D>();
    }

    void OnEnable()
    {
        renderer.enabled = true;
        attack.enabled = true;
        collider.enabled = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            if (deathClip != null &&
                enemyAudio != null)
            {
                enemyAudio.PlayOneShot(deathClip);
            }

            renderer.enabled = false;
            attack.enabled = false;
            collider.enabled = false;

            Invoke("Disable", 0.5f);
        }
        else
        {
            if (damageClip != null &&
                enemyAudio != null)
            {
                enemyAudio.PlayOneShot(damageClip);
            }
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
