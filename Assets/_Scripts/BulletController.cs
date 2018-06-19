using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public float velocity;
    public int playerID;
    public FloatVariable damage;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        this.rigidBody.AddRelativeForce(new Vector3(velocity, 0, 0));
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerInput>().GetHurt(playerID, damage);
        }
        Destroy(this.gameObject);
    }
}