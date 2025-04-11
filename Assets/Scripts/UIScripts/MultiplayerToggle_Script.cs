using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerToggle_Script : MonoBehaviour
{
    public void toggleMutliplayer()
    {
        if (GameManager_Script.instance != null)
        {
            GameManager_Script.instance.toggleMultiplayer();
        }
    }
}
