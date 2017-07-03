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

   
    void OnTriggerEnter(Collider other)
    {
        //if (other.GameObject.comparetag("Player"))
        //{

        //}
       // Destroy(other.gameObject);
    }


   public void TakeDmg(float pDamage)
    {
        Health -= pDamage;
        if(Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.FindObjectOfType<UIManager>().SoulFragments += SoulValue;
        Destroy(gameObject);
    }
}


