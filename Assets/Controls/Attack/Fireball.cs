using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Rigidbody ProjectileRB;



        private int pFired;
        private int pDestroyed;
        private float lastShot = 0.0f;
        private int RoundsFired = 0;

    public float speed = 10;
    public float targetTime = 0.1f;

    // Use this for initialization
    void Start()
    {
        GameObject Projectile = new GameObject("Fireball"); // Make a new GO.
        Rigidbody ProjectileRB = Projectile.AddComponent<Rigidbody>(); // Add the rigidbody.   
    }
    // Update is called once per frame
    void Update()
    {
        Fire();
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

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Enemy")
        {
            Destroy(this);
            Destroy(col.gameObject);
        }
    }


}

