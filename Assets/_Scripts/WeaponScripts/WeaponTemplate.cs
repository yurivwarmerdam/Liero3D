using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTemplate :MonoBehaviour
{
    public PlayerInput player;

    abstract public void shoot();

}
