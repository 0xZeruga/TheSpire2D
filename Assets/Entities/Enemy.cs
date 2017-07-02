using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Player;
    public Projectile Projectile;
    public int speed = 10;
    public int Health = 100;
    private int MaxDist = 0;
    private int MinDist = 0;



    // Use this for initialization
    void Start()
    {

        var target = Player.transform;

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //RotateChar();

        //var Towards = Vector3.MoveTowards(transform.position, Player.transform.position, 1000);
    }

    void Update()
    {
        var p = Player.GetComponent<Collider>();
        var proj = Projectile.GetComponent<Collider>();
        OnTriggerEnter(p);
        OnTriggerEnter(proj);
      
    }

   
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}


