using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Rigidbody ProjectileRB;

    public float speed = 10;

        private int pFired;
        private int pDestroyed;
        private float lastShot = 0.0f;
        private int RoundsFired = 0;

        public float targetTime = 0.1f;

        
       


    // Use this for initialization
    void Start()
    {
        GameObject Projectile = new GameObject("Fireballz"); // Make a new GO.
        Rigidbody ProjectileRB = Projectile.AddComponent<Rigidbody>(); // Add the rigidbody.
        

        // Fireball.transform.position = Player.transform.rotation

       // targetTime = 0.2f;

    }
    // Update is called once per frame
    void Update()
    {
        Fire();
        //CheckTimer();
    

    }

    public void Fire()
    {
        if (Input.GetMouseButton(0)) 
        {
                
             
                if (Time.time > targetTime + lastShot)
                {
                    ProjectileRB = Instantiate(ProjectileRB,
                                                                    this.transform.position,
                                                                    this.transform.rotation)
                         as Rigidbody;

                    ProjectileRB.velocity = transform.TransformDirection(new Vector3(0, 180, speed));
                    lastShot = Time.time;
                RoundsFired++;
                 
                }         
        }

       
    }

    void OnBecameInvisible()
    {
       
    }
}

