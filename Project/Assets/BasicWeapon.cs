using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netaphous.Utilities;

public abstract class BasicWeapon : BasicPoolManager
{
    [SerializeField]
    protected bool singleShot = true;
    [SerializeField]
    protected float fireRate = 0.5f;
    [SerializeField]
    private int clipSize = 10;
    [SerializeField]
    private KeyCode reloadKey = KeyCode.R;
    [SerializeField]
    private float reloadTime = 1.0f;
    [SerializeField]
    protected float spreadAmount = 5.0f;

    protected int bulletsInClip = 0;

    protected bool canFire = true;
    private bool reloading = false;

    // Use this for initialization
    protected void Start ()
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

    protected abstract void Fire();

    protected void FireSingleBullet(Transform bulletSpawn)
    {
        canFire = false;
        GameObject bullet = GetPooledItem();

        float randomSpread = Random.Range(-spreadAmount, spreadAmount);

        Quaternion newRot = Quaternion.Euler(0.0f, 0.0f, bulletSpawn.eulerAngles.z + randomSpread);

        if (bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = newRot;
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
