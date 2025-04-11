using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float damage;
    public Pawn_Script owner;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        //Get the health component from the gameObject that has a collider with health
        Health_Script hitThing = col.gameObject.GetComponent<Health_Script>();
        
        //Only damage if there is a health component
        if (hitThing != null )
        {
            //Damage
            hitThing.takeDamage(damage, owner);

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        //Destroy bullet
        Destroy(gameObject);
    }
}
