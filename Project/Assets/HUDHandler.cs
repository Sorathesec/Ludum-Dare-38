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
    private static HUDHandler instance;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        instance = this;
        playerHealth = player.GetComponent<PlayerHealth>();
        UpdateUI();
    }

    public static void UpdateUI()
    {
        instance.healthSlider.value = instance.playerHealth.GetHealth();
    }

    public static void SetThirstMax(int value)
    {
        instance.thirstSlider.maxValue = value;
    }
}
