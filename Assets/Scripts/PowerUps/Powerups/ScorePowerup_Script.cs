using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ScorePowerup_Script : PowerupBase_Script
{
    public int amount;

    public override void Apply(PowerupManager_Script target)
    {
        Pawn_Script targetPawn = target.GetComponent<Pawn_Script>();

        if(targetPawn != null)
        {
            targetPawn.controller.addToScore(amount);
        }
    }

    public override void Remove(PowerupManager_Script target)
    {
        Pawn_Script targetPawn = target.GetComponent<Pawn_Script>();

        if (targetPawn != null)
        {
            targetPawn.controller.addToScore(-amount);
        }
    }
}
