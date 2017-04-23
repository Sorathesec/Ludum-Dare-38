using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField]
    private BiomeType[] biomes;
    [SerializeField]
    private GameObject[] weapons;

    private BiomeType currentBiome;

    public void UpdateBiome(BiomeType newBiome)
    {
        if(currentBiome != newBiome)
        {
            currentBiome = newBiome;
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        for(int i = 0; i < biomes.Length; i++)
        {
            if(biomes[i] == currentBiome)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

    public void DisableWeapons()
    {
        foreach(GameObject obj in weapons)
        {
            obj.SetActive(false);
        }
    }
}
