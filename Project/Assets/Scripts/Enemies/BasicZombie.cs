using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicZombie : ZombieHealth
{
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

        Invoke("Disable", 0.5f);
    }
}
