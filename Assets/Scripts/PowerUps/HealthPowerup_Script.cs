using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class HealthPowerup_Script : PowerupBase_Script
{
    public float healthToAdd;

    public float healthToRemove;

    public override void Apply(PowerupManager_Script target)
    {
        Health_Script targetHealth = target.GetComponent<Health_Script>();

        if (targetHealth != null)
        {
            targetHealth.heal(healthToAdd, target.GetComponent<Pawn_Script>());
        }
    }

    public override void Remove(PowerupManager_Script target)
    {
        Health_Script targetHealth = target.GetComponent<Health_Script>();

        if (targetHealth != null)
        {
            targetHealth.takeDamage(healthToRemove, target.GetComponent<Pawn_Script>());
        }
    }
}
