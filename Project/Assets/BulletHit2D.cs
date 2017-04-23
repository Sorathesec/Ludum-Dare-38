using UnityEngine;
using System.Collections;

public class BulletHit2D : MonoBehaviour
{
    // Public variables
    // To be set in the editor
    public int damage = 1;
    public string damageTag = "";
	[HideInInspector]
	public int health = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag (damageTag)) 
		{
			other.SendMessage ("TakeDamage", damage);
            
			health--;
			if (health > 0) 
			{
				return;
			}
			gameObject.SetActive (false);
		}
    }
}
