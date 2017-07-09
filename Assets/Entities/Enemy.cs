using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 10;
    public float Health;
    private int MaxDist = 0;
    private int MinDist = 0;

    public int SoulValue = 10;
    public Rigidbody SoulFragmentRB;



    // Use this for initialization
    void Start()
    {
        Health  = 100f;
       

    }

    void Update()
    {
        // var p = Player.GetComponent<Collider>();
        //  var proj = Projectile.GetComponent<Collider>();
        //OnTriggerEnter(p);
        //OnTriggerEnter(proj);
        
      
    }


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Fireball")
        {
            Destroy(gameObject);
            Debug.Log("FireballCollision");
        }
        else if (col.gameObject.name == "Player")
        {
            //TakeDmg(20f);
            Destroy(gameObject);
            Debug.Log("PlayerCollision");
        }
    }


    public void TakeDmg(float pDamage)
    {
        Health -= pDamage;
        if(Health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.FindObjectOfType<Character>().SoulFragments += SoulValue;
        SpawnSoulFragment(this.transform.position);
        Destroy(gameObject);
    }

    public void SpawnSoulFragment(Vector3 pPos)
    {

        SoulFragmentRB = Instantiate(SoulFragmentRB,
                                                         this.transform.position,
                                                         this.transform.rotation)
              as Rigidbody;

        }
    }



