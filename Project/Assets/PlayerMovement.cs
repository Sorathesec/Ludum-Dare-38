using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    private Vector2 direction;
    
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        direction = new Vector2(x, y);
        direction.Normalize();
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
