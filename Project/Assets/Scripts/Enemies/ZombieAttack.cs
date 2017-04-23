using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    PlayerHealth playerHealth;                  // Reference to the player's health.
    ZombieHealth enemyHealth;                    // Reference to this enemy's health.

    bool canAttack = true;

    void Start()
    {
        enemyHealth = GetComponent<ZombieHealth>();

        GameObject player = GameObject.FindWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnEnable()
    {
        canAttack = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && 
            enemyHealth.GetHealth() > 0 &&
            canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        print(playerHealth);
        canAttack = false;

        playerHealth.TakeDamage(attackDamage);

        Invoke("CanAttackAgain", timeBetweenAttacks);
    }

    void CanAttackAgain()
    {
        canAttack = true;
    }
}