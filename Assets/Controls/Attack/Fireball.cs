using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody FireballRB;

    public float speed = 10;

    private void Start()
    {
        Rigidbody FireballRB = gameObject.GetComponent<Rigidbody>();
        FireballRB.velocity = transform.TransformDirection(new Vector3(0, 180, speed));
    }

}

