using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int value)
    {
        currentHealth -= value;
        if(currentHealth <= 0)
        {
            EventManager.TriggerEvent("PlayerDead");
        }
        HUDHandler.UpdateUI();
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
