using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCredits_Script : MonoBehaviour
{
    public void changeCredits()
    {
        if (GameManager_Script.instance != null)
        {
            GameManager_Script.instance.activateCreditsScreen();
        }
    }
}
