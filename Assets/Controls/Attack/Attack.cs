using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    /// <summary>
    /// This is a basescripts that features a virtual function for attack depending on whether Stance is range or melee.
    /// </summary>

	// Use this for initialization
	void Start () {

        //var stance = Character.Stance.MELEE;
        if (Input.GetMouseButtonDown(0))
        {
            new Spin();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            new Projectile();
        }
        else if (Input.GetMouseButtonDown(2))
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
