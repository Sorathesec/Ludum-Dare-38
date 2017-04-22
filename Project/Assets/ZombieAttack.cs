using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    private GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    IsShootable enemyHealth;                    // Reference to this enemy's health.
    bool shootableInRange;
    bool playerInRange=false;                         // Whether player is within the trigger collider and can be attacked.
    float timer = 1f;                           // Timer for counting up to the next attack.
    private BoxCollider2D attackRangeCollider;

    void Start()
    {
        enemyHealth = GetComponent<IsShootable>();
        attackRangeCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player");
        }

        playerHealth = player.GetComponent<PlayerHealth>();

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && enemyHealth.health > 0 && playerInRange==true)
        {
            // ... attack.
            Attack();
        }
    }

    void Attack()
    {
        // Reset the timer.
        timer = 0f;

         // ... damage the player.
         playerHealth.TakeDamage(attackDamage);

    }

}
