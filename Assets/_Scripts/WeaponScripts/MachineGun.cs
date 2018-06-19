using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;


public class MachineGun  : WeaponTemplate {

    public GameObject bulletPrefab;
    public FloatVariable weaponCooldown;

    private Transform bulletSpawnTransform;
    private float cooldown;

    // Use this for initialization
    void Start () {
        bulletSpawnTransform = this.transform.Find("BulletSpawn");
        cooldown = weaponCooldown.value;
    }

    // Update is called once per frame
    void Update() {
        if (cooldown<weaponCooldown.value)
        {
            cooldown += Time.deltaTime;
        }
    }

    public override void shoot()
    {
        if (cooldown >= weaponCooldown.value)
        {
            Vector3 location = bulletSpawnTransform.position;

            Quaternion bulletRotation = bulletSpawnTransform.rotation;
            bulletRotation *= Quaternion.Euler(0, 0, -90);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, location, bulletRotation);
            bulletGO.GetComponent<BulletController>().playerID = player.playerID;
            cooldown = 0;
        }
        
    }
}
