using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    private Transform target;
    public float speed = 5.0f;
    private bool isMoving = false;
    private Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (GameObject.FindWithTag("Player"))
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        if (target != null)
        {
            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("isMoving", true);
            }
        }
    }
}