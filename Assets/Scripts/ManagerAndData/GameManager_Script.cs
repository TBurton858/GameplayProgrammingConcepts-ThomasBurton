using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using TMPro;

public class GameManager_Script : MonoBehaviour
{
    //Gamemanager variable, static so it belongs to the class and not the object
    public static GameManager_Script instance;

    //Variables for player controller and pawn
    public GameObject playerControllerPrefab;
    public GameObject secondControllerPrefab;
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
    public bool multiplayer;

    public GameObject[] enemyTypes;

    public GameObject[] correspondingControllers;

    public int enemiesToSpawn;

    public bool totalEnemies;

    public Camera UICamera;

    //Game States
    public GameObject titleScreenStateObject;
    public GameObject mainMenuStateObject;
    public GameObject optionsScreenStateObject;
    public GameObject creditsScreenStateObject;
    public GameObject gameplayStateObject;
    public GameObject gameOverScreenStateObject;

    public bool checkGameOver = false;

    public bool titleStart;

    public TMP_Text highScoreText;
    public TMP_Text currentScoreText;

    public int highScore;
    public int currentScore;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        if (titleStart)
        {
            activateTitleScreen();
        }
    }

    void loadMap()
    {
        if (mapGenerator != null)
        {
            mapGenerator.GenerateMap();
        }

        doorDestroyer.destroyDoors();

        tankPawnSpawners = FindObjectsByType<TankPawnSpawners_Script>(FindObjectsSortMode.None);

        spawnEnemies();
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
        highScoreText.text = "" + highScore;
        currentScoreText.text = "" + currentScore;

        if (checkGameOver)
        {
            if (players.Count > 0)
            {
                if (multiplayer)
                {
                    if (players[1].pawn.GetComponent<TankHealth_Script>().lives <= 0)
                    {
                        activateGameOver();
                    }
                }
                if (players[0].pawn.GetComponent<TankHealth_Script>().lives <= 0)
                {
                    activateGameOver();
                }
            }
        }
    }

    public void scoreOnDeath(int score)
    {
        currentScore = score;

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }

    public void respawn(GameObject tank)
    {
        Transform tankPawnSpawnPoint = tankPawnSpawners
                [UnityEngine.Random.Range(0, tankPawnSpawners.Length)].transform;

        tank.transform.position = tankPawnSpawnPoint.position;
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
                tankPawn.controller = playerController;

                if (multiplayer)
                {
                    Camera camera = pawnObj.GetComponentInChildren<Camera>();

                    camera.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);

                    Transform tankPawnSpawnPoint2 = tankPawnSpawners
                    [UnityEngine.Random.Range(0, tankPawnSpawners.Length)].transform;

                    GameObject playerObj2 = Instantiate(secondControllerPrefab, Vector3.zero,
                    Quaternion.identity) as GameObject;
                    GameObject pawnObj2 = Instantiate(tankPawnPrefab, tankPawnSpawnPoint2.position,
                    tankPawnSpawnPoint2.rotation) as GameObject;

                    Camera camera2 = pawnObj2.GetComponentInChildren<Camera>();

                    camera2.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);

                    Controller_Script playerController2 =
                    playerObj2.GetComponent<Controller_Script>();

                    playerObj2.GetComponent<Controller_Script>();
                    Pawn_Script tankPawn2 = pawnObj2.GetComponent<Pawn_Script>();

                    playerController2.pawn = tankPawn2;
                    tankPawn2.controller = playerController2;
                }
            }
        }
    }

    private void deactivateAllStates()
    {
        //Deactivate all game states

        titleScreenStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsScreenStateObject.SetActive(false);
        creditsScreenStateObject.SetActive(false);
        gameplayStateObject.SetActive(false);
        gameOverScreenStateObject.SetActive(false);

        checkGameOver = false;

        UICamera.targetDisplay = 0;
    }

    public void activateTitleScreen()
    {
        deactivateAllStates();

        titleScreenStateObject.SetActive(true);
    }

    public void activateMainMenu()
    {
        deactivateAllStates();

        mainMenuStateObject.SetActive(true);
    }

    public void activateOptionsScreen()
    {
        deactivateAllStates();

        optionsScreenStateObject.SetActive(true);
    }

    public void activateCreditsScreen()
    {
        deactivateAllStates();

        creditsScreenStateObject.SetActive(true);
    }

    public void activateGameplay()
    {
        titleStart = false;

        loadMap();

        deactivateAllStates(); 

        gameplayStateObject.SetActive(true);

        spawnPlayer();

        checkGameOver = true;

        UICamera.targetDisplay = 1;
    }

    public void activateGameOver()
    {
        deactivateAllStates();

        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i].pawn);

            Destroy(enemies[i]);
        }

        for (int i = 0; i < players.Count; i++)
        {
            Destroy(players[i].pawn);

            Destroy(players[i]);
        }

        players.Clear();
        enemies.Clear();

        GameObject[] powerups = GameObject.FindGameObjectsWithTag("Power");

        for (int i = 0; i < powerups.Length; i++)
        {
            Destroy (powerups[i]);
        }

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");

        for (int i = 0; i < rooms.Length; i++)
        {
            Destroy(rooms[i]);
        }

        titleStart = true;

        gameOverScreenStateObject.SetActive(true);
    }

    public void quitGame()
    {
        //Exits game in editor
        //EditorApplication.Exit(0);

        //Exits game 
        Application.Quit();
    }

    public void toggleMapOfDay()
    {
        useSeed = !useSeed;
    }

    public void toggleMultiplayer()
    {
        multiplayer = !multiplayer;
    }
}
