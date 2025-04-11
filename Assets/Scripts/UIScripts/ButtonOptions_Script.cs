using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOptions_Script : MonoBehaviour
{
    public void changeOptions()
    {
        if (GameManager_Script.instance != null)
        {
            GameManager_Script.instance.activateOptionsScreen();
        }
    }
}
