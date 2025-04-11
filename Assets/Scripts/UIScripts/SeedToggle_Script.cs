using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedToggle_Script : MonoBehaviour
{
    public void toggleSeed()
    {
        if (GameManager_Script.instance != null)
        {
            GameManager_Script.instance.toggleMapOfDay();
        }
    }
}
