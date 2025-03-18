using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager_Script : MonoBehaviour
{
    //Gamemanager variable, static so it belongs to the class and not the object
    public static GameManager_Script instance;

    //Variables for player controller and pawn
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    //Transform variable
    private TankPawnSpawners_Script[] tankPawnSpawners;

    //List that holds players
    public List<PlayerController_Script> players;

    public List<AIController_Script> enemies;

    public MapGenerator_Script mapGenerator;

    public DoorDestroyer_Script doorDestroyer;

    public int mapSeed;

    public bool useSeed;

    public GameObject[] enemyTypes;

    public GameObject[] correspondingControllers;

    public int enemiesToSpawn;

    public bool totalEnemies;

    private void Awake()
    {
        if (useSeed)
        {
            UnityEngine.Random.InitState(mapSeed);
        }
        else
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now.Date));
        }

        //UnityEngine.Random.InitState(DateToInt(DateTime.Now));

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

        players = new List<PlayerController_Script>();
        enemies = new List<AIController_Script>();

        if (mapGenerator != null)
        {
            mapGenerator.GenerateMap();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        doorDestroyer.destroyDoors();

        tankPawnSpawners = FindObjectsByType<TankPawnSpawners_Script>(FindObjectsSortMode.None);

        spawnEnemies();

        //Runs funtion at the start of the game
        spawnPlayer();
    }

    public void spawnEnemies()
    {
        if (!totalEnemies)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                for (int j = 0; j < enemyTypes.Length; j++)
                {
                    spawnTheEnemy(enemyTypes[j], correspondingControllers[j]);
                }
            }
        }
        else
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int choosenEnemy = UnityEngine.Random.Range(0, enemyTypes.Length);

                spawnTheEnemy(enemyTypes[choosenEnemy], correspondingControllers[choosenEnemy]);
            }
        }
    }

    public void spawnTheEnemy(GameObject enemyTank, GameObject enemyController)
    {
        Transform tankPawnSpawnPoint = tankPawnSpawners
                    [UnityEngine.Random.Range(0, tankPawnSpawners.Length)].transform;

        //Spawn the enemy controller at 0,0,0 with no rotation
        GameObject currentController = Instantiate(enemyController, Vector3.zero,
            Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject enemyPawnObj = Instantiate(enemyTank, tankPawnSpawnPoint.position,
            tankPawnSpawnPoint.rotation) as GameObject;

        //Get the enemy controller component and pawn component.
        AIController_Script referenceController =
            currentController.GetComponent<AIController_Script>();
        Pawn_Script tankPawn = enemyPawnObj.GetComponent<Pawn_Script>();

        //Hooking the controller
        referenceController.pawn = tankPawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0].pawn.GetComponent<TankHealth_Script>().currentHealth <= 0)
        {
            Transform tankPawnSpawnPoint = tankPawnSpawners
                    [UnityEngine.Random.Range(0, tankPawnSpawners.Length)].transform;

            players[0].pawn.transform.position = tankPawnSpawnPoint.position;
        }
    }

    public int DateToInt (DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + 
            dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }

    public void spawnPlayer()
    {
        if (tankPawnSpawners != null)
        {
            if (tankPawnSpawners.Length > 0)
            {
                Transform tankPawnSpawnPoint = tankPawnSpawners
                    [UnityEngine.Random.Range(0, tankPawnSpawners.Length)].transform;

                //Spawn the player controller at 0,0,0 with no rotation
                GameObject playerObj = Instantiate(playerControllerPrefab, Vector3.zero,
                    Quaternion.identity) as GameObject;

                //Spawn the pawn and connect it to the controller
                GameObject pawnObj = Instantiate(tankPawnPrefab, tankPawnSpawnPoint.position,
                    tankPawnSpawnPoint.rotation) as GameObject;

                //Get the player controller component and pawn component.
                Controller_Script playerController =
                    playerObj.GetComponent<Controller_Script>();
                Pawn_Script tankPawn = pawnObj.GetComponent<Pawn_Script>();

                //Hooking the controller
                playerController.pawn = tankPawn;
            }
        }
    }
}
