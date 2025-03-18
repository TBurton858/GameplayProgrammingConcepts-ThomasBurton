using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPowerupsAround_Script : MonoBehaviour
{
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, turnSpeed * Time.deltaTime, 0.0f, Space.World);
    }
}
