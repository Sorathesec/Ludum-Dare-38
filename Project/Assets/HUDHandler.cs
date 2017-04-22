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
    private Slider ThirstSlider;

    private GameObject player;

    private PlayerHealth playerHealth;
    private PlayerHunger playerHunger;
    private static HUDHandler instance;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        instance = this;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHunger = player.GetComponent<PlayerHunger>();
        UpdateUI();
    }

    public static void UpdateUI()
    {
        instance.healthSlider.value = instance.playerHealth.GetHealth();
        instance.hungerSlider.value = instance.playerHunger.GetHunger();
    }
}
