using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover_Script : Mover_Script
{
    //Variable holds the rigidbody
    private Rigidbody rb;

    //Variable holds the transform component
    private Transform tf;

    public override void Start()
    {
        //Set values to respective components
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    public override void Update()
    {
        
    }
    public override void Move(Vector3 direction, float moveSpeed)
    {
        Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + moveVector);
    }

    public override void Rotate(float turnSpeed)
    {
        tf.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
