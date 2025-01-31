using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller_Script : MonoBehaviour
{
    //Reference the pawn with variable
    public Pawn_Script pawn;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void processInputs();
}
