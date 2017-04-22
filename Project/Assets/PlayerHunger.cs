using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class PlayerHunger : MonoBehaviour
{
    [SerializeField]
    private int maxHunger = 100;
    [SerializeField]
    private int reductionRate = 1;
    [SerializeField]
    private int starvingDamage = 5;
    [SerializeField]
    private int starvingRate = 5;

    private int currentHunger;
    private PlayerHealth health;
    private bool isStarving = false;

    void Awake ()
    {
        health = GetComponent<PlayerHealth>();
        currentHunger = maxHunger;
        StartCoroutine(ReduceHunger());
	}
    void Start()
    {
        HUDHandler.SetHungerMax(maxHunger);
    }
	
	private IEnumerator ReduceHunger ()
    {
        while (true)
        {
            yield return new WaitForSeconds(reductionRate);
            RemoveHunger(1);
        }
	}

    private void RemoveHunger(int value)
    {
        currentHunger -= value;
        if(currentHunger < 0)
        {
            currentHunger = 0;
        }
        TestHungerLevel();
    }

    public void RestoreHunger(int value)
    {
        currentHunger += value;
        if(currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
        TestHungerLevel();
    }

    public int GetHunger()
    {
        return currentHunger;
    }

    private void TestHungerLevel()
    {
        if (currentHunger == 0)
        {
            EventManager.TriggerEvent("Starving");
            if (!isStarving)
            {
                isStarving = true;
                StartCoroutine(Starving());
            }
        }
        else if(currentHunger <= maxHunger / 5)
        {
            EventManager.TriggerEvent("Hungry");
            if (isStarving)
            {
                isStarving = false;
                StopCoroutine(Starving());
            }
        }
        else
        {
            EventManager.TriggerEvent("NotHungry");
        }
        HUDHandler.UpdateUI();
    }
    private IEnumerator Starving()
    {
        while (true)
        {
            yield return new WaitForSeconds(starvingRate);
            health.TakeDamage(starvingDamage);
        }
    }
}