using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager_Script : MonoBehaviour
{
    public List<PowerupBase_Script> powerups;

    private List<PowerupBase_Script> removePowerupQueue;

    // Start is called before the first frame update
    void Start()
    {
        powerups = new List <PowerupBase_Script>();

        removePowerupQueue = new List <PowerupBase_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        decrementPowerupTimers();
    }

    private void LateUpdate()
    {
        applyRemovePowerupsQueue();
    }

    public void Add(PowerupBase_Script powerupToAdd)
    {
        powerupToAdd.Apply(this);

        powerups.Add(powerupToAdd);
    }

    public void Remove(PowerupBase_Script powerupToRemove)
    {
        powerupToRemove.Remove(this);

        removePowerupQueue.Add(powerupToRemove);
    }

    public void decrementPowerupTimers()
    {
        foreach (PowerupBase_Script powerup in powerups)
        {
            if (!powerup.isPermanent)
            {
                powerup.duration -= Time.deltaTime;

                if (powerup.duration <= 0)
                {
                    Remove(powerup);
                }
            }
        }
    }

    public void applyRemovePowerupsQueue()
    {
        foreach (PowerupBase_Script powerup in removePowerupQueue)
        {
            powerups.Remove(powerup);
        }

        removePowerupQueue.Clear();
    }
}
