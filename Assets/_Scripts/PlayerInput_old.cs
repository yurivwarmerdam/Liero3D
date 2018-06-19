using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_old : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    public GameObject bulletPrefab;
    public float jumpCooldownTimer;
    public float aimSpeed;

    private Rigidbody rigidBody;
    private bool isFalling = false;
    private float jumpCooldown;
    private Transform gunTransform;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        jumpCooldown = 0;
        gunTransform = transform.Find("Gun");
        
    }

    private void Update()
    {
        float verticalAim = Input.GetAxis("Vertical");
        bool shoot = Input.GetButtonDown("Fire1");

        if ((gunTransform.rotation.eulerAngles.z<=145 && verticalAim>0) | (gunTransform.rotation.eulerAngles.z >= 35 && verticalAim<0))
        {
            gunTransform.Rotate(0, 0, verticalAim * Time.deltaTime * aimSpeed);
        }


        if (shoot)
        {
            Vector3 location = this.transform.position;
            location.x = location.x + 0.8f;
            location.y = location.y + 0.3f;
            Quaternion bulletRotation = gunTransform.rotation;
            bulletRotation *= Quaternion.Euler(0, 0, -90);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, location, bulletRotation);
            bulletGO.GetComponent<Rigidbody>().velocity = rigidBody.velocity;
        }

    }

    // Update is called once per frame
    void FixedUpdate () {
        
        float horizontalMove = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        

        //handles horizontal movement
        if (System.Math.Abs(rigidBody.velocity.x) < 13)
        {
            rigidBody.AddForce(new Vector3(horizontalMove, 0, 0) * speed);
        }

        //handles jumping
        //this whole jumpcooldown thingy is ugly.
        jumpCooldown -= Time.deltaTime;
        if (jump && !isFalling)
        {
            rigidBody.AddForce(Vector3.up*jumpHeight);
            isFalling = true;
            
            jumpCooldown = jumpCooldownTimer;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        isFalling = false;
    }

}