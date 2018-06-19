using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponTemplate
{
    PlayerInput player { get; set; }
    void shoot();
}
