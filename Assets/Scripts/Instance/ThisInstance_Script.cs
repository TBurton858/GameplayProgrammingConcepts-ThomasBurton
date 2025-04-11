using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisInstance_Script : MonoBehaviour
{
    private ThisInstance_Script instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            //This is the instance
            //
            instance = this;
            //Do not destroy if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //If there is already an instance, destroy this gameObject
            Destroy(gameObject);
        }
    }
}
