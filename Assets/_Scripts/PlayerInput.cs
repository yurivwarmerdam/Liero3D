﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class PlayerInput : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpHeight;
    public float aimSpeed;
    public GameObject bulletPrefab;
    public FloatVariable maxHP;
    public FloatVariable HP;
    public FloatVariable kills;
    public FloatVariable friendlyFire;
    public CharacterInputManager characterInputManager;
    public GameObject weapon;

    public int playerID;

    private CharacterController characterController;
    private float verticalVelocity;
    private GameObject selectedWeapon;
    private Transform gunTransform;
    private Vector3 spawnPoint;
    private WeaponTemplate weaponScript;
    

    private static List<GameObject> players = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        //TODO: clean up all these private & public things I no longer need
        selectedWeapon= (GameObject)Instantiate(weapon, this.gameObject.transform);
        weaponScript= selectedWeapon.GetComponent<WeaponTemplate>();
        weaponScript.player = this;
        characterController = GetComponent <CharacterController> ();
        gunTransform = selectedWeapon.transform;
        spawnPoint = this.transform.position;
        HP.value = maxHP.value;
        kills.value = 0;
        playerID=getPlayerID(this.gameObject);
    }

    public int getPlayerID(GameObject player)
    {
        players.Add(player);
        return players.Count-1;
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis(characterInputManager.horizontalAxis);
        float verticalAim = Input.GetAxis(characterInputManager.verticalAxis);
        bool shoot = Input.GetButton(characterInputManager.Fire1);

        //handles horizontal movement
        if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if (horizontalMovement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //aim gun
        if ((gunTransform.rotation.eulerAngles.z <= 145 && verticalAim > 0) | (gunTransform.rotation.eulerAngles.z >= 35 && verticalAim < 0))
        {
            gunTransform.Rotate(0, 0, verticalAim * Time.deltaTime * aimSpeed);
        }

        //shoot gun
        if (shoot)
        {
            weaponScript.shoot();
            /*
            Vector3 location = bulletSpawnTransform.position;

            Quaternion bulletRotation = bulletSpawnTransform.rotation;
            bulletRotation *= Quaternion.Euler(0, 0, -90);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, location, bulletRotation);
            bulletGO.GetComponent<BulletController>().playerID = this.playerID;
            */
        }

        
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis(characterInputManager.horizontalAxis);
        bool jump = Input.GetButton(characterInputManager.Jump);

        Vector3 frameMovement = Vector3.zero;

        //TODO: change everything so vector3 movement is used and characterController.move is only called once per frame.

        //handles horizontal movement
        
        frameMovement.x += speed * Time.deltaTime * horizontalMovement;
     

        //handles falling & jumping

        if (!characterController.isGrounded)
        {
            if (verticalVelocity <= 0 || !jump)
            {
                verticalVelocity -= 1.5f * gravity * Time.deltaTime;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
        }
        else { verticalVelocity = 0; }

        if (jump && characterController.isGrounded)
        {
            verticalVelocity = jumpHeight;
        }

        frameMovement.y += verticalVelocity * Time.deltaTime;
        characterController.Move(frameMovement);
    }

    public void GetHurt(int damagingPlayer, FloatVariable damage)
    {
        if (damagingPlayer != playerID || friendlyFire.value == 1)
        {
            HP.value -= damage.value;
        }
        if (HP.value <= 0)
        {
            Respawn();
            if (damagingPlayer != playerID)
            {
                players[damagingPlayer].GetComponent<PlayerInput>().kills.value += 1;
            }
        }
    }

    private void Respawn()
    {
        this.transform.position = spawnPoint;
        HP.value = maxHP.value;
    }
}