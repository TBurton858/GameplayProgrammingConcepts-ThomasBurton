using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter_Script : Shooter_Script
{
    public Transform firePoint;

    public AudioSource audioShoot;
    // Start is called before the first frame update
    public override void Start()
    {
        audioShoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void shoot
        (GameObject bullet, float fireForce, float damage, float lifespan)
    {
        if(audioShoot != null)
        {
            audioShoot.Play();
        }

        GameObject newBullet = Instantiate(bullet, firePoint.position,
            firePoint.rotation);

        Bullet_Script theBullet = newBullet.GetComponent<Bullet_Script>();
        
        if (theBullet != null )
        {
            theBullet.damage = damage;

            theBullet.owner = GetComponent<Pawn_Script>();
        }

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(firePoint.forward * fireForce);
        }

        Destroy(newBullet, lifespan);
    }
}
