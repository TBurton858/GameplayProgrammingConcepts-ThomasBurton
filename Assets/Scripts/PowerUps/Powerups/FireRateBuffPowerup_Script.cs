using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class FireRateBuffPowerup_Script : PowerupBase_Script
{
    public float fireRateAmount;

    public override void Apply(PowerupManager_Script target)
    {
        Pawn_Script targetPawn = target.GetComponent<Pawn_Script>();

        if (targetPawn != null)
        {
            targetPawn.fireRate += fireRateAmount;
        }
    }

    public override void Remove(PowerupManager_Script target)
    {
        Pawn_Script targetPawn = target.GetComponent<Pawn_Script>();

        if (targetPawn != null)
        {
            targetPawn.fireRate -= fireRateAmount;
        }
    }
}
