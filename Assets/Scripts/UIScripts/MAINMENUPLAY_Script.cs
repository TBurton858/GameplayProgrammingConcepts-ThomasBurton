using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENUPLAY_Script : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene(0);

        GameManager_Script.instance.enemies.Clear();
        GameManager_Script.instance.players.Clear();
    }
}
