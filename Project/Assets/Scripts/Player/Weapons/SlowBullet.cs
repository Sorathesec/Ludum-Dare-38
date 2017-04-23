using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : Bullet2D
{
    protected override void CollisionAction(Collider2D other)
    {
        other.SendMessage("TakeDamage", damage);
        other.SendMessage("Slowed");

        health--;
        if (health > 0)
        {
            return;
        }
        gameObject.SetActive(false);
    }
}