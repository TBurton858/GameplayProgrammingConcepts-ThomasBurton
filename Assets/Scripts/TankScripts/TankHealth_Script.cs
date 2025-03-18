using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth_Script : Health_Script
{
    public bool respawn;

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

    public override void Die(Pawn_Script source)
    {
        if (!respawn)
        {
            Destroy(gameObject);
        }
    }
}
