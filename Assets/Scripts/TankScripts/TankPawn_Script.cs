using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn_Script : Pawn_Script
{
    private float secondsPerShot;

    private float nextShootTime;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        secondsPerShot = 1 / fireRate;

        nextShootTime = Time.time + secondsPerShot;
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

    public override void moveForward(float speed)
    {
        mover.Move(transform.forward, speed);
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

    public override void shoot()
    {
        if(Time.time >= nextShootTime)
        {
            shooter.shoot(bullet, fireForce, damage, lifespan);

            nextShootTime = Time.time + secondsPerShot;
        }
    }

    public override void rotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        transform.rotation = Quaternion.RotateTowards
            (transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
