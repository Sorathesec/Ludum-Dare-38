using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class PlayerThirst : MonoBehaviour
{

    [SerializeField]
    private int maxThirst = 100;
    [SerializeField]
    private int reductionRate = 1;
    private int currentThirst;

    void Awake()
    {
        currentThirst = maxThirst;
        StartCoroutine(ReduceThirst());
    }

    private IEnumerator ReduceThirst()
    {
        while (true)
        {
            yield return new WaitForSeconds(reductionRate);
            RemoveThirst(1);
        }
    }

    private void RemoveThirst(int value)
    {
        currentThirst -= value;
        if (currentThirst < 0)
        {
            currentThirst = 0;
        }
        TestThirstLevel();
    }

    public void RestoreThirst(int value)
    {
        currentThirst += value;
        if (currentThirst > maxThirst)
        {
            currentThirst = maxThirst;
        }
        TestThirstLevel();
    }

    public int GetThirst()
    {
        return currentThirst;
    }

    private void TestThirstLevel()
    {
        if (currentThirst == 0)
        { 
            EventManager.TriggerEvent("Dehydrated");
        }
        else if (currentThirst <= maxThirst / 5)
        {
            EventManager.TriggerEvent("Thirsty");
        }
        else
        {
            EventManager.TriggerEvent("NotThirsty");
        }
        HUDHandler.UpdateUI();
    }
}
