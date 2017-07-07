using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public Animator animator;

	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
    public void MeleeAnim() {          //   Call this to trigger the melee animation.
        animator.SetTrigger("Melee");  //   TODO: Pass in a direction, e.g. Melee(left); and trigger corresponding animation.
    }
}
