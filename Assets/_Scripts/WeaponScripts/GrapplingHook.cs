using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;


public class GrapplingHook: WeaponTemplate {

    public GameObject bulletPrefab;
    //public FloatVariable weaponCooldown;

    private Transform bulletSpawnTransform;
    private GameObject firedBullet;

    // Use this for initialization
    void Start () {
        bulletSpawnTransform = this.transform.Find("BulletSpawn");
    }

    // Update is called once per frame
    void Update() {
  
    }

    public override void autoFire()
    {

    }

    public override void manualFire()
    {
        if (firedBullet == null)
        {
            Vector3 location = bulletSpawnTransform.position;
            Quaternion bulletRotation = bulletSpawnTransform.rotation;
            bulletRotation *= Quaternion.Euler(0, 0, -90);
            firedBullet = (GameObject)Instantiate(bulletPrefab, location, bulletRotation);
            firedBullet.GetComponent<ProjectileTemplate>().player = playerRB;
        }
        else
        {
            Destroy(firedBullet);
        }
    }

}
