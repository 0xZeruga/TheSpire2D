using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Attack {

    public float Damage = 1;

	// Use this for initialization
	void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DoProjectileHit()
    {
        gameObject.GetComponent<Enemy>().TakeDmg(Damage);
        Destroy(gameObject);
    }
}
