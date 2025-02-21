using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolType_Script : AIController_Script
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
            case aiState.Chase:
                //Chase stuff
                doChaseState();
                if (!canHear(target) && !canSee(target))
                {
                    changeState(aiState.Patrol);
                }
                if (canSee(target))
                {
                    changeState(aiState.Attack);
                }
                break;

            case aiState.Attack:
                //Attack stuff
                doAttackState();
                if (!canSee(target))
                {
                    changeState(aiState.Chase);
                }
                break;

            case aiState.Patrol:
                doPatrolState();
                if (canHear(target) || canSee(target))
                {
                    changeState(aiState.Chase);
                }
                break;
        }
    }
}
