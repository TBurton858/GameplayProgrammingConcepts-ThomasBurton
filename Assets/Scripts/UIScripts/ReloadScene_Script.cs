using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene_Script : MonoBehaviour
{
    public void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
