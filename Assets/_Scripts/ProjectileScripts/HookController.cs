using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookController : ProjectileTemplate
{
    public Vector3Variable distance;
    public FloatVariable attractionForce;

    private Rigidbody rigidBody;
    private Rigidbody playerRigidBody;
    private Boolean isAnchored;
    
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        this.rigidBody.AddRelativeForce(new Vector3(velocity, 0, 0));
        isAnchored = false;
        distance = (Vector3Variable)ScriptableObject.CreateInstance("Vector3Variable");
    }

    private void Update()
    {
        if (isAnchored)
        {
            distance.value = this.transform.position - player.transform.position;
            Debug.Log(distance.value);
            player.AddForce(distance.value.normalized * Time.deltaTime * attractionForce.value);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        isAnchored = true;

        /* TODO: maybe keep this. Think about it.
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerInput>().GetHurt(playerID, damage);
        }
        */

    }

    private void AttractPlayer()
    {

    }
}