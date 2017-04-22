using UnityEngine;
using System.Collections;

public class Bullet2D : MonoBehaviour
{
    // Public variables
    // To be set in the editor
    public float speed = 5.0f;
    public float destroyTime = 0.7f;

    // Private variables
    // Code optimisation
    private Rigidbody2D theRigidbody2D;

    void Start()
    {
        theRigidbody2D = GetComponent<Rigidbody2D>();
    }

	void OnEnable () {
        Invoke("Die", destroyTime);
	}

    void Die()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke("Die");
    }

    void FixedUpdate()
    {
        theRigidbody2D.velocity = transform.up * speed;
    }
}
