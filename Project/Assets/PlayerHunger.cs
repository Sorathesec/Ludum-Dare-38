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
    private int currentHunger;

    void Awake ()
    {
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
        }
        else if(currentHunger <= maxHunger / 5)
        {
            EventManager.TriggerEvent("Hungry");
        }
        else
        {
            EventManager.TriggerEvent("NotHungry");
        }
        HUDHandler.UpdateUI();
    }
}