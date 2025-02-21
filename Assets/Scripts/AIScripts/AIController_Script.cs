using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIController_Script : Controller_Script
{
    public enum aiState { Guard, Chase, Attack, Flee, Patrol };

    public aiState currentState;

    public GameObject target;

    public float triggerDistance;
    public float fleeDistance;

    public Transform[] wayPoints;
    public float stopToWayPoint;

    public int currentPoint;

    public float fovAngle;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        //Do we have a gameManager that exists
        if (GameManager_Script.instance != null)
        {
            //And it tracks the player(s)
            if (GameManager_Script.instance.enemies != null)
            {
                //Register with gameManager
                GameManager_Script.instance.enemies.Add(this);
            }
        }

        //currentState = aiState.Guard;
    }

    // Update is called once per frame
    public override void Update()
    {
        /*
        //If there is no specific target, then make it the player
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        */

        //If ishastarget is false
        if (!isHasTarget())
        {
            //Find player one
            targetPlayerOne();

            Debug.Log("Looking");
        }

        //If ishastarget is true
        if (isHasTarget())
        {
            //Process inputs
            processInputs();

            Debug.Log("Found");
        }

        base.Update();
    }

    //Where decision making happens
    public override void processInputs()
    {
        switch (currentState)
        {
            case aiState.Guard:
                doGuardState();
                break;

            case aiState.Chase:
                //Chase stuff
                doChaseState();
                break;

            case aiState.Attack:
                //Attack stuff
                doAttackState();
                break;

            case aiState.Flee:
                doFleeState();
                break;

            case aiState.Patrol:
                doPatrolState();
                break;
        }
    }

    //The state functions
    public void doGuardState()
    {
        //Do nothing
    }

    public void doChaseState()
    {
        //Seek our target
        seek(target);
    }

    public void doAttackState()
    {
        seek(target);

        shoot();
    }

    public void doFleeState()
    {
        flee();
    }

    public void doPatrolState()
    {
        patrol();
    }

    public void shoot()
    {
        pawn.shoot();
    }

    //Functions for behaviors of the FSM
    public void seek(GameObject target)
    {
        seek(target.transform.position);
    }

    public void seek(Vector3 targetPosition)
    {
        pawn.rotateTowards(targetPosition);

        pawn.moveForward();
    }

    public void seek(Transform targetTransform)
    {
        seek(targetTransform.position);
    }

    public void seek(Pawn_Script targetPawn)
    {
        seek(targetPawn.transform);
    }

    public void flee()
    {
        //Find vector to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //Find the vector away from our target by multiplying by -1
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        //Find the vector we would travel down in order to flee
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;

        seek(pawn.transform.position + fleeVector);
    }

    public void patrol()
    {
        //If we have enough waypoints in our list to move current waypoint
        if (wayPoints.Length > currentPoint)
        {
            //Then seek the waypoint
            seek(wayPoints[currentPoint]);
            //If we are close enough, then increase waypoint
            if (Vector3.Distance(pawn.transform.position, wayPoints[currentPoint].position) 
                <= stopToWayPoint)
            {
                currentPoint++;
            }
        }
        else
        {
            restartPatrol();
        }
    }

    public void restartPatrol()
    {
        //Set index to 0
        currentPoint = 0;
    }

    //Helper transition functions
    public bool isDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance (pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Change state helper function
    public void changeState(aiState state)
    {
        currentState = state;
    }

    public void targetPlayerOne()
    {
        //If there is a game instance, there is players, and the amount is greater than 0, do the following
        if (GameManager_Script.instance != null && GameManager_Script.instance.players != null
            && GameManager_Script.instance.players.Count > 0)
        {
            //Target is player 1
            target = GameManager_Script.instance.players[0].pawn.gameObject;
        }
        /*
        //The better version:
        target = GameObject.FindGameObjectWithTag("Player");
        */
    }

    protected bool isHasTarget()
    {
        //return value if there is or is not target
        return target != null;
    }

    public bool canHear(GameObject target)
    {
        //Get noiseMaker
        NoiseMaker_Script noiseMaker = target.GetComponent<NoiseMaker_Script>();

        //If no noiseMaker, return false
        if (noiseMaker == null)
        {
            return false;
        }

        //If no sound return false
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }

        //If distance between player and this pawn is less than or equal to hearing distance
        if (Vector3.Distance (pawn.transform.position, target.transform.position)
            <= noiseMaker.volumeDistance)
        {
            //If above was true return true
            return true;
        }
        else
        {
            //If above is false return false
            return false;
        }
    }

    //Checking to see if enemy sees player
    public bool canSee(GameObject target)
    {
        //This value is target position subtracked by pawn position
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;

        //This value is the angle of the vector value above and pawn facing forward
        float angleToTarget = Vector3.Angle(vectorToTarget, pawn.transform.forward);

        //If angleToTarget is less than or equal to fovAngle do the following
        if (angleToTarget <= fovAngle)
        {
            //Max raycast value basicly
            RaycastHit hit;

            //raycast casts from this pawn, angled forward relitive to pawn, hitting anything pulls true
            if (Physics.Raycast(pawn.transform.position, pawn.transform.forward, out hit))
            {
                //If what you hit is the target
                if (hit.transform.gameObject == target)
                {
                    return true;
                }
            }
        }

        //If no value is pulled above, then it is false
        return false;
    }
}
