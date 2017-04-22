using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHandler : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Slider hungerSlider;
    [SerializeField]
    private Slider thirstSlider;

    private GameObject player;

    private PlayerHealth playerHealth;
    private PlayerHunger playerHunger;
    private PlayerThirst playerThirst;
    private static HUDHandler instance;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        instance = this;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHunger = player.GetComponent<PlayerHunger>();
        playerThirst = player.GetComponent<PlayerThirst>();
        UpdateUI();
    }

    public static void UpdateUI()
    {
        instance.healthSlider.value = instance.playerHealth.GetHealth();
        instance.hungerSlider.value = instance.playerHunger.GetHunger();
        instance.thirstSlider.value = instance.playerThirst.GetThirst();
    }

    public static void SetThirstMax(int value)
    {
        instance.thirstSlider.maxValue = value;
    }
    public static void SetHungerMax(int value)
    {
        instance.hungerSlider.maxValue = value;
    }
    public static void SetHealthMax(int value)
    {
        instance.healthSlider.maxValue = value;
    }
}
