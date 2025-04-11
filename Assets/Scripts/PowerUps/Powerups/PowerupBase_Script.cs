using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase_Script
{
    public float duration;

    public bool isPermanent;

    public abstract void Apply(PowerupManager_Script target);
    public abstract void Remove(PowerupManager_Script target);
}
