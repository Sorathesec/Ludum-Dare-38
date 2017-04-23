using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWeapon : BasicWeapon
{
    [SerializeField]
    private int numOfBullets = 3;
    [SerializeField]
    private Transform[] bulletSpawns;
    
    protected override void Fire()
    {
        canFire = false;

        for(int i = 0; i < numOfBullets; i++)
        {
            FireSingleBullet(bulletSpawns[i]);

            if(bulletsInClip <= 0)
            {
                break;
            }
        }

        Invoke("ReadyToFire", fireRate);
    }
}
