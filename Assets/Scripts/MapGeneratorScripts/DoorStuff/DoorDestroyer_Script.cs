using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroyer_Script : MonoBehaviour
{
    public GameObject[] doors;

    public float leeWay;

    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    public void destroyDoors()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");

        for (int i = 0; i < doors.Length; i++)
        {
            for (int j = 0; j < doors.Length; j++)
            {
                float distance = Vector3.Distance
                        (doors[i].transform.position, doors[j].transform.position);

                if (i != j)
                {
                    if (distance <= leeWay)
                    {
                        Destroy(doors[i]);
                        Destroy(doors[j]);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
