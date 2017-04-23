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
                EventManager.TriggerEvent("PlayerDead");
                gameObject.SetActive(false);
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
