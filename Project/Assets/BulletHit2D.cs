using UnityEngine;
using System.Collections;

public class BulletHit2D : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private string damageTag = "";
	[SerializeField]
	private int health = 1;

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
