using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Script : Controller_Script
{
    //Variables for keys
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode moveClockwiseKey;
    public KeyCode moveCounterClockwiseKey;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        processInputs();

        base.Update();
    }

    public override void processInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.moveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.moveBackward();
        }

        if (Input.GetKey(moveClockwiseKey))
        {
            pawn.rotateClockwise();
        }

        if (Input.GetKey(moveCounterClockwiseKey))
        {
            pawn.rotateCounterClockwise();
        }
    }
}
