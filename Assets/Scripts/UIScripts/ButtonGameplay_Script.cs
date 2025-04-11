using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameplay_Script : MonoBehaviour
{
    public void changeGameplay()
    {
        if (GameManager_Script.instance != null)
        {
            GameManager_Script.instance.activateGameplay();
        }
    }
}
