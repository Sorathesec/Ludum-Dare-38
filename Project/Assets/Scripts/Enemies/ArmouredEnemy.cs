using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmouredEnemy : BasicZombie
{

    public new void TakeDamage(int damage)
    {
        damage -= 5;
        if(damage <= 0)
        {
            damage = 1;
        }

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
}
