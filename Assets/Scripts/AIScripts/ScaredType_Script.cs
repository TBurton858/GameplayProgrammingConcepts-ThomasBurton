using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AIController_Script;

public class ScaredType_Script : AIController_Script
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        currentState = aiState.Patrol;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void processInputs()
    {
        switch (currentState)
        {
            case aiState.Flee:
                doFleeState();
                if(!canHear(target) && !canSee(target))
                {
                    changeState(aiState.Patrol);
                }
                break;

            case aiState.Patrol:
                doPatrolState();
                if (canHear(target) || canSee(target))
                {
                    changeState(aiState.Flee);
                }
                break;
        }
    }
}
