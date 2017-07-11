using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Attack {

    
    public GameObject Fireball;
    //public GameObject Enemy;
    private int pFired;
    private int pDestroyed;
    private float lastShot = 0.0f;
    private int RoundsFired = 0;

    public float targetTime = 0.1f;

    // Use this for initialization
    void Start()
    {

       // Rigidbody Fireball = Fireball.AddComponent<Rigidbody>(); // Add the rigidbody.   


    }
    // Update is called once per frame
    void Update()
    {
        FireCheck();
    }

    public void FireCheck()
    {
        if (Input.GetMouseButton(0))
        {

            if (Time.time > targetTime + lastShot)
            {
               // Instantiate(Fireball);
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
        //if (col.name == "Enemy")
        //{
        //   // Destroy(this);
        //    Destroy(this);
        //    Destroy(col.gameObject);
        //}



    }


}

