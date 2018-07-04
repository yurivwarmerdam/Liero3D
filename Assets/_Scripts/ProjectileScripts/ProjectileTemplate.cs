using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProjectileTemplate: MonoBehaviour
{
    public float velocity;
    public int playerID;
    public FloatVariable damage;
    public Rigidbody player;

}