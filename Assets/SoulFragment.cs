using Assets.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFragment : MonoBehaviour
{

    private Collider SoulCollider;
    private Character C;
   
    // Use this for initialization
    void Start()
    {
        SoulCollider  = GetComponent<Collider>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //void OnTriggerEnter(Collider other)
    //{
    //SoulCollider = other;
    ////Destroy the GameObject that Collides with this
    ////Destroy(col.gameObject);
    //C.Gold += 10;
    //Destroy(other.gameObject);
    //}


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
