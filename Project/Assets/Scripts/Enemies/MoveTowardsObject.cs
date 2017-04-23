using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {
    [SerializeField]
    private Transform target;
    public float speed = 5.0f;
    private Animator enemyAnimator;
    [SerializeField]
    private float slowMultiplier = 0.4f;
    [SerializeField]
    private float slowDuration = 10.0f;

    private bool slowed = false;

    private new Rigidbody2D rigidbody;
    [SerializeField]

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        if (GameObject.FindWithTag("Player"))
        {
            //target = GameObject.FindWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.angularVelocity = 0.0f;
            }
            float realSpeed = speed * 0.01f;
            if(slowed)
            {
                realSpeed *= slowMultiplier;
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, realSpeed);
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("isMoving", true);
            }
        }
    }

    void Slowed()
    {
        slowed = true;
        Invoke("NotSlowed", slowDuration);
    }

    void NotSlowed()
    {
        slowed = false;
    }
}