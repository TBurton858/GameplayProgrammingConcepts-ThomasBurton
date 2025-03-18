using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup_Script : MonoBehaviour
{
    public HealthPowerup_Script powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        PowerupManager_Script powerupManager = col.GetComponent<PowerupManager_Script>();

        if (powerupManager != null)
        {
            powerupManager.Add(powerup);

            Destroy(gameObject);
        }
    }
}
