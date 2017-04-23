using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPiece : MonoBehaviour
{
    [SerializeField]
    private Vector2 direction;
    private float speed = 1.0f;
    private int damage = 1;
    private string damageTag = "";
    private int maxHealth = 3;
    private int health = 3;

    public void Activate()
    {
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(true);
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        health = maxHealth;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage);

            health--;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    public void SetDamageTag(string tag)
    {
        damageTag = tag;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
    public void SetHealth(int value)
    {
        maxHealth = value;
    }
}
