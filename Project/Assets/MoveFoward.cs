using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    [SerializeField]
    float speed = 2.0f;

    void FixedUpdate()
    {
         GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
    }
}
