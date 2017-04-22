using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private Vector2 direction;

    private Rigidbody2D theRigidbody;
    float x;
    float y;

	void Start ()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        direction = new Vector2(x, y);
        direction.Normalize();
	}

    void FixedUpdate()
    {
        theRigidbody.velocity = direction * speed;
    }
}
