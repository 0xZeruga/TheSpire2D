using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    public Fireball Fireball;
    public PlayerAnimations playerAnimations; 

	void Start () {
        Fireball = GetComponent<Fireball>();
        playerAnimations = GetComponent<PlayerAnimations>();
	}
	
	void Update () {
        if (Input.GetMouseButton(0)) {
            Fireball.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            MeleeAttack();
        }
    }

    private void MeleeAttack() {
        // Execute melee attack related code here (dealing damage etc)

        playerAnimations.MeleeAnim();  // This calls the MeleeAnim() function from PlayerAnimations.cs
    }
}
