using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SpeedUpBuffPowerup_Script : PowerupBase_Script
{
    public float speedUpAmount;

    public float turnSpeedUpAmount;

    public override void Apply(PowerupManager_Script target)
    {
        Pawn_Script targetPawn = target.GetComponent<Pawn_Script>();

        if (targetPawn != null)
        {
            targetPawn.moveSpeed += speedUpAmount;

            targetPawn.turnSpeed += turnSpeedUpAmount;
        }
    }

    public override void Remove(PowerupManager_Script target)
    {
        Pawn_Script targetPawn = target.GetComponent<Pawn_Script>();

        if (targetPawn != null)
        {
            targetPawn.moveSpeed -= speedUpAmount;

            targetPawn.turnSpeed -= turnSpeedUpAmount;
        }
    }
}
