using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public class BasicWeapon : BasicPoolManager
{
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    private bool singleShot = true;
    [SerializeField]
    private float fireRate = 0.5f;

    private bool canFire = true;

    // Use this for initialization
    void Start ()
    {
        CreatePool();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (canFire)
        {
            if (singleShot)
            {
                SingleShot();
            }
            else
            {
                RapidShot();
            }
        }
    }

    private void Fire()
    {
        canFire = false;
        GameObject bullet = GetPooledItem();

        if (bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.SetActive(true);
        }
        Invoke("ReadyToFire", fireRate);
    }

    private void SingleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void RapidShot()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }
    private void ReadyToFire()
    {
        canFire = true;
    }
}
