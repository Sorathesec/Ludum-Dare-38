using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : BasicWeapon
{
    [SerializeField]
    private Transform bulletSpawn;
    protected override void Fire()
    {
        canFire = false;
        FireSingleBullet(bulletSpawn);

        Invoke("ReadyToFire", fireRate);
    }
}
