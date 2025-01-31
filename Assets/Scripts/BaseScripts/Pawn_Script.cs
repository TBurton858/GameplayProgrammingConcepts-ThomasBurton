using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn_Script : MonoBehaviour
{
    //Modifiable values
    public float moveSpeed;
    public float turnSpeed;

    public Mover_Script mover;
    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover_Script>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void moveForward();
    public abstract void moveBackward();
    public abstract void rotateClockwise();
    public abstract void rotateCounterClockwise();
}
