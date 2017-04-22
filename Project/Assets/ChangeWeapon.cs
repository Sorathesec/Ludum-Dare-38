using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    private BiomeType currentBiome;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
        print("New biome: " + currentBiome);
    }
}
