using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject Player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       var C = this.transform.position;
       var P = Player.transform.position;
        C = P;
    }
}
