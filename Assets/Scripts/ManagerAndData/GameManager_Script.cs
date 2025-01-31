using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{
    //Gamemanager variable, static so it belongs to the class and not the object
    public static GameManager_Script instance;

    //Variables for player controller and pawn
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    //Transform variable
    public Transform playerSpawn;

    private void Awake()
    {
        //If the instance does not exist
        if (instance == null)
        {
            //This is the instance
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

    // Start is called before the first frame update
    void Start()
    {
        //Runs funtion at the start of the game
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPlayer()
    {
        //Spawn the player cntroller at 0,0,0 with no rotation
        GameObject playerObj = Instantiate(playerControllerPrefab, Vector3.zero,
            Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject pawnObj = Instantiate(tankPawnPrefab, playerSpawn.position, 
            playerSpawn.rotation) as GameObject;

        //Get the player controller component and pawn component.
        Controller_Script playerController = 
            playerObj.GetComponent<Controller_Script>();
        Pawn_Script tankPawn = pawnObj.GetComponent<Pawn_Script>();

        //Hooking the controller
        playerController.pawn = tankPawn;
    }
}
