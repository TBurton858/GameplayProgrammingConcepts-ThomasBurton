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
    public KeyCode shootKey;

    public float volumeDistance;
    
    // Start is called before the first frame update
    public override void Start()
    {
        //Do we have a gameManager that exists
        if (GameManager_Script.instance != null)
        {
            //And it tracks the player(s)
            if (GameManager_Script.instance.players != null)
            {
                //Register with gameManager
                GameManager_Script.instance.players.Add(this);
            }
        }
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        processInputs();

        base.Update();

        TankHealth_Script playerHealth = pawn.GetComponent<TankHealth_Script>();

        if (playerHealth.currentHealth <= 0)
        {
            playerHealth.currentHealth = playerHealth.maxHealth;
        }
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

        if (Input.GetKey(shootKey))
        {
            pawn.shoot();
        }

        //If you push any input then sound
        if (Input.GetKey(moveForwardKey) || Input.GetKey(moveBackwardKey) ||
            Input.GetKey(moveClockwiseKey) || Input.GetKey(moveCounterClockwiseKey) ||
            Input.GetKey(shootKey))
        {
            pawn.noiseMaker.volumeDistance = volumeDistance;

            
        }
        //If no input, no sound
        else
        {
            pawn.noiseMaker.volumeDistance = 0;
        }
    }

    public void OnDestroy()
    {
        //Check there is a gameManager
        if (GameManager_Script.instance != null)
        {
            //Check the gameManager has players
            if (GameManager_Script.instance.players != null)
            {
                //Remove this from players list
                GameManager_Script.instance.players.Remove(this);
            }
        }
    }
}
