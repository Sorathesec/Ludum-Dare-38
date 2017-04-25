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
                AudioManager.PlayAudioClip(playerDeath, 1);
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<ChangeWeapon>().DisableWeapons();
                Invoke("Dead", 0.5f);
                Invoke("EndGame", 5.0f);
            }
            else {
                AudioManager.PlayAudioClip(playerAudio, 1);
            }
            HUDHandler.UpdateUI();
        }
    }

    private void Dead()
    {
        GameObject.Find("GameOver").GetComponent<Animator>().SetBool("GameOver", true);
    }

    private void EndGame()
    {
        LoadScene.instance.LoadLevel("StartScreen");
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
