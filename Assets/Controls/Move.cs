using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 25.0f;
    private float lastShot = 0.0f;
    private float reload = 0.5f;
    private int pFired;

    private void Start()
    {
        pFired = 0;
    }

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
        RotateChar();
        //CheckFire();
    }

    private void RotateChar()
    {
        // Char = pChar;
        if (Input.GetMouseButton(1))
        {
            //Rotate Towards Position
            var mouse = Input.mousePosition;
            var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

    }

    //private void CheckFire()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        if (Time.time > reload + lastShot)
    //        {
    //            new Fireball();
    //            pFired++;
    //            lastShot = Time.time;
    //        }
    //    }


    //}

}