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
    [SerializeField]
    private int clipSize = 10;
    [SerializeField]
    private KeyCode reloadKey = KeyCode.R;
    [SerializeField]
    private float reloadTime = 1.0f;
    [SerializeField]
    private float spreadAmout = 5.0f;

    private int bulletsInClip = 0;

    private bool canFire = true;
    private bool reloading = false;

    // Use this for initialization
    void Start ()
    {
        CreatePool();

        bulletsInClip = clipSize;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!reloading)
        {
            if (bulletsInClip == 0)
            {
                TryReload();
            }
            else if (canFire)
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
    }

    private void Fire()
    {
        canFire = false;
        GameObject bullet = GetPooledItem();
        Transform realSpawn = bulletSpawn;
        
        float randomSpread = Random.Range(-spreadAmout, spreadAmout);
        
        realSpawn.localRotation = Quaternion.Euler(0.0f, 0.0f, randomSpread - 90);

        if (bullet != null)
        {
            bullet.transform.position = realSpawn.position;
            bullet.transform.rotation = realSpawn.rotation;
            bullet.SetActive(true);
        }
        bulletsInClip--;
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

    private void TryReload()
    {
        if(Input.GetMouseButton(0) ||
            Input.GetKeyDown(reloadKey))
        {
            Invoke("Reload", reloadTime);
            reloading = true;
            print("Reloading");
        }
    }

    private void Reload()
    {
        bulletsInClip = clipSize;
        print("Reloaded");
        reloading = false;
    }
}
