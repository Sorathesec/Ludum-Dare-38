using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 currentChunk = new Vector2(2, 2);
    [SerializeField]
    private float speed = 1.0f;
    private Vector2 direction;

    private Rigidbody2D theRigidbody;
    private ChangeWeapon weapons;
    float x;
    float y;

	void Start ()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
        weapons = GetComponent<ChangeWeapon>();
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

    private bool triggering = false;
    private BiomeType newBiome;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Chunk")
        {
            if (!triggering)
            {
                triggering = true;
                WorldChunk chunk = other.GetComponent<WorldChunk>();
                currentChunk = chunk.chunkIndex;
                newBiome = chunk.GetBiomeType();
                Invoke("BiomeChange", 0.05f);
                GetComponentInChildren<SwitchSprite>().ChangeSprite(newBiome);
            }
        }
    }

    private void BiomeChange()
    {
        weapons.UpdateBiome(newBiome);
        triggering = false;
    }
}
