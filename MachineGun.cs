using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;


public class MachineGun  : MonoBehaviour,WeaponTemplate {

    public GameObject bulletPrefab;
    public PlayerInput player { get; set; }

    private Transform bulletSpawnTransform;

    // Use this for initialization
    void Start () {
        bulletSpawnTransform = this.transform.Find("BulletSpawn");
    }

    // Update is called once per frame
    void Update() {

    }

    public void shoot()
    {
        Vector3 location = bulletSpawnTransform.position;

        Quaternion bulletRotation = bulletSpawnTransform.rotation;
        bulletRotation *= Quaternion.Euler(0, 0, -90);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, location, bulletRotation);
        bulletGO.GetComponent<BulletController>().playerID = player.playerID;
    }
}
