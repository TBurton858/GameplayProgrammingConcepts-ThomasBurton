using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn_Script : MonoBehaviour
{
    //Modifiable values
    public float moveSpeed;
    public float turnSpeed;

    //Component references
    public Mover_Script mover;
    public Shooter_Script shooter;
    public NoiseMaker_Script noiseMaker;

    //Variables for shooter
    public GameObject bullet;
    public float fireForce;
    public float damage;
    public float lifespan;
    public float fireRate;

    // Start is called before the first frame update
    public virtual void Start()
    {
        //Get respective component in game object
        mover = GetComponent<Mover_Script>();
        shooter = GetComponent<Shooter_Script>();
        noiseMaker = GetComponent<NoiseMaker_Script>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void moveForward();
    public abstract void moveForward(float speed);
    public abstract void moveBackward();
    public abstract void rotateClockwise();
    public abstract void rotateCounterClockwise();

    public abstract void shoot();

    public abstract void rotateTowards(Vector3 targetPosition);
}
