using UnityEngine;
using System.Collections;

public abstract class Bullet2D : MonoBehaviour
{
    // Public variables
    // To be set in the editor
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float destroyTime = 0.7f;
    [SerializeField]
    protected int damage = 1;
    [SerializeField]
    private string damageTag = "";
    [SerializeField]
    protected int health = 1;

    // Private variables
    // Code optimisation
    private Rigidbody2D theRigidbody2D;

    protected void Awake()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            CollisionAction(other);
        }
    }

    protected abstract void CollisionAction(Collider2D other);
}
