using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    [SerializeField]
    private AudioClip playerAudio;
    [SerializeField]
    private AudioClip playerDeath;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        HUDHandler.SetHealthMax(maxHealth);
    }
    public void TakeDamage(int value)
    {
        if (currentHealth > 0)
        {
            
            currentHealth -= value;
            if (currentHealth <= 0)
            {
                AudioManager.PlayAudioClip(playerDeath);
                EventManager.TriggerEvent("PlayerDead");
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<ChangeWeapon>().DisableWeapons();
            }
            else {
                AudioManager.PlayAudioClip(playerAudio);
            }
            HUDHandler.UpdateUI();
        }
    }

    public void Heal(int value)
    {
        currentHealth += value;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        HUDHandler.UpdateUI();
    }
    public int GetHealth()
    {
        return currentHealth;
    }
}
