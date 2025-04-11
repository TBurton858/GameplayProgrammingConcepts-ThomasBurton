using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner_Script : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;

    private GameObject spawnedPickup;

    private bool soundPlayed;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();

        nextSpawnTime = Time.time + spawnDelay;

        audioSource = GetComponent<AudioSource>();

        soundPlayed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedPickup == null)
        {
            if (!soundPlayed)
            {
                audioSource.Play();

                soundPlayed = true;
            }

            int powerupToSpawn = Random.Range(0, pickupPrefabs.Length);

            if (Time.time > nextSpawnTime)
            {
                spawnedPickup = Instantiate(pickupPrefabs[powerupToSpawn],
                    tf.position, tf.rotation);

                nextSpawnTime = Time.time + spawnDelay;

                soundPlayed = false;
            }
        }
        else
        {
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
