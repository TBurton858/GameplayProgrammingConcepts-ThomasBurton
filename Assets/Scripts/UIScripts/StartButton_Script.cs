using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton_Script : MonoBehaviour
{
    public void changeMainMenu()
    {
        if(GameManager_Script.instance != null)
        {
            GameManager_Script.instance.activateMainMenu();
        }
    }
}
