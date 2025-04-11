using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton_Script : MonoBehaviour
{
    public void quitTheGame()
    {
        if (GameManager_Script.instance != null)
        {
            GameManager_Script.instance.quitGame();
        }
    }
}
