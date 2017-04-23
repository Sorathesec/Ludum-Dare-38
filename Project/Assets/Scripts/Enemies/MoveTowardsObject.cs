using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    private Transform target;
    public float speed = 5.0f;
    private Animator enemyAnimator;
    [SerializeField]
    private float slowMultiplier = 0.4f;
    [SerializeField]
    private float slowDuration = 10.0f;

    private bool slowed = false;

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