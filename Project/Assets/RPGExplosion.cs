using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGExplosion : MonoBehaviour
{
    private ExplosionPiece[] pieces;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float destroyTime = 0.7f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private string damageTag = "";
    [SerializeField]
    private int health = 3;

    void Awake()
    {
        pieces = GetComponentsInChildren<ExplosionPiece>();

        foreach (ExplosionPiece piece in pieces)
        {
            piece.SetDamage(damage);
            piece.SetDamageTag(damageTag);
            piece.SetSpeed(speed);
            piece.SetHealth(health);
        }
    }

	// Use this for initialization
	void OnEnable ()
    {
		foreach(ExplosionPiece piece in pieces)
        {
            piece.Activate();
        }
        Invoke("Die", destroyTime);
    }

    void Die()
    {
        foreach (ExplosionPiece piece in pieces)
        {
            piece.Die();
        }
        gameObject.SetActive(false);
    }
}
