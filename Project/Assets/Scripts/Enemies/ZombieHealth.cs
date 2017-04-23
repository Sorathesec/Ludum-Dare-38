using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombieHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;

    protected AudioClip deathClip;
    protected AudioClip damageClip;
    protected AudioSource enemyAudio;
    protected SpriteRenderer renderer;
    protected ZombieAttack attack;
    protected CircleCollider2D collider;
    protected BoxCollider2D trigger;
    protected int health;

    public void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        attack = GetComponent<ZombieAttack>();
        collider = GetComponent<CircleCollider2D>();
        trigger = GetComponent<BoxCollider2D>();
    }

    void OnEnable()
    {
        Initialise();
    }

    private void Initialise()
    {
        renderer.enabled = true;
        attack.enabled = true;
        collider.enabled = true;
        trigger.enabled = true;

        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else if (damageClip != null &&
                enemyAudio != null)
        {
            enemyAudio.PlayOneShot(damageClip);
        }
    }

    protected abstract void Die();

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SetDeathClip(AudioClip clip)
    {
        deathClip = clip;
    }

    public void SetDamageClip(AudioClip clip)
    {
        damageClip = clip;
    }

    public int GetHealth()
    {
        return health;
    }
}
