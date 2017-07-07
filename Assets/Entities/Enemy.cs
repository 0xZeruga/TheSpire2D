using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 10;
    public int Health = 100;
    private int MaxDist = 0;
    private int MinDist = 0;



    // Use this for initialization
    void Start()
    {

       
    }

    void Update()
    {
       // var p = Player.GetComponent<Collider>();
      //  var proj = Projectile.GetComponent<Collider>();
        //OnTriggerEnter(p);
        //OnTriggerEnter(proj);
       
      
    }

   
    void OnTriggerEnter(Collider other)
    {
        //if (other.GameObject.comparetag("Player"))
        //{

        //}
       // Destroy(other.gameObject);
    }

}


