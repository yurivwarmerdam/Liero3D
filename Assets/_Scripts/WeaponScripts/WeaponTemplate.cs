using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTemplate :MonoBehaviour
{
    public PlayerInput player;
    public Rigidbody playerRB;

    abstract public void manualFire();
    abstract public void autoFire();

}
