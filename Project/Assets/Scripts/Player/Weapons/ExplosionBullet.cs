﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : Bullet2D
{
    [SerializeField]
    private GameObject prefab;

    private GameObject explosion;
	// Use this for initialization
	void Awake ()
    {
        base.Awake();
        explosion = Instantiate(prefab, transform.position, transform.rotation);
        explosion.SetActive(false);
    }

    protected override void CollisionAction(Collider2D other)
    {
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);
        gameObject.SetActive(false);
    }
}