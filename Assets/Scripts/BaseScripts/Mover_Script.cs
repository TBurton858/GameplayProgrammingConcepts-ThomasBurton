using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void Move(Vector3 direction, float moveSpeed);

    public abstract void Rotate(float turnSpeed);
}
