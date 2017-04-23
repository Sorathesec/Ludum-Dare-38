﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WormPieceID
{
    Head, Body, Tail
}
public class WormEnemyPiece : ZombieHealth
{
    [SerializeField]
    private WormPieceID piece = WormPieceID.Body;

    public static Sprite headSprite;
    public static Sprite bodySprite;
    public static Sprite tailSprite;
    public static int headDamage;
    public static int bodyDamage;
    public bool dead = false;
    protected bool canDie = true;
    
    private WormLook look;
    private HingeJoint2D joint;
    private MoveFoward move;
    private new Rigidbody2D rigidbody;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
        attack = GetComponent<ZombieAttack>();
        look = GetComponent<WormLook>();
        joint = GetComponent<HingeJoint2D>();
        move = GetComponent<MoveFoward>();
        rigidbody = GetComponent<Rigidbody2D>();


        ResetComponents();
    }

    protected override void Die()
    {
        if (canDie)
        {
            ResetComponents();
            gameObject.SetActive(false);
            dead = true;
            transform.parent.GetComponent<WormEnemy>().PieceDied(this);
            enemyAudio.PlayOneShot(deathClip);
        }
        else
        {
            health = 1;
        }
    }

    private void ResetComponents()
    {
        switch (piece)
        {
            case WormPieceID.Head:
                MakeHead();
                break;
            case WormPieceID.Body:
                MakeBody();
                break;
            case WormPieceID.Tail:
                MakeTail();
                break;
        }
    }

    public void MakeHead()
    {
        renderer.sprite = headSprite;
        collider.enabled = true;
        collider.offset = new Vector2(-0.01f, 0);
        collider.radius = 0.18f;
        attack.attackDamage = headDamage;
        look.enabled = true;
        joint.enabled = true;
        joint.useLimits = false;
        move.speed = 5;
        rigidbody.mass = 1;
        rigidbody.freezeRotation = true;
        canDie = true;
    }

    public void MakeBody()
    {
        renderer.sprite = bodySprite;
        attack.attackDamage = bodyDamage;
        look.enabled = false;
        joint.enabled = true;
        joint.useLimits = false;
        move.speed = 2;
        rigidbody.mass = 3;
        rigidbody.freezeRotation = false;
        canDie = false;
    }

    public void MakeTail()
    {
        renderer.sprite = tailSprite;
        collider.offset = new Vector2(0.11f, 0);
        collider.radius = 0.14f;
        attack.attackDamage = bodyDamage;
        move.speed = 2;
        if (piece != WormPieceID.Tail)
        {
            look.enabled = false;
            joint.enabled = false;
        }
        canDie = true;
    }
}
