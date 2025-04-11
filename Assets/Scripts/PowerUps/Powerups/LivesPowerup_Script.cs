using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesPowerup_Script : PowerupBase_Script
{
    public int livesAdd;

    public override void Apply(PowerupManager_Script target)
    {
        TankHealth_Script targetHealth = target.GetComponent<TankHealth_Script>();

        if (targetHealth != null)
        {
            targetHealth.lives += livesAdd;
        }
    }

    public override void Remove(PowerupManager_Script target)
    {
        TankHealth_Script targetHealth = target.GetComponent<TankHealth_Script>();

        if (targetHealth != null)
        {
            targetHealth.lives -= livesAdd;
        }
    }
}
