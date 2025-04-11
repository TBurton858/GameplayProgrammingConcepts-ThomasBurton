using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth_Script : Health_Script
{
    public bool respawn;

    public bool destroy = true;

    public int lives;

    public AudioSource audioSource;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        updateHealth();
    }

    public override void Die(Pawn_Script source)
    {
        base.Die(source);

        if (!respawn)
        {
            lives--;
        }

        if (!respawn && lives <= 0)
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            GameManager_Script.instance.respawn(this.gameObject);

            currentHealth = maxHealth;

            updateHealth();
        }
    }
}
