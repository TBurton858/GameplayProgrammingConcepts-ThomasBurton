using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn_Script : Pawn_Script
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void moveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }

    public override void moveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void rotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void rotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }
}
