using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 25.0f;
   // private float lastShot = 0.0f;
   // private float reload = 0.5f;
    private int pFired;

    //Dash shit
    public Vector3 moveDirection;
    public float MaxDashTime = 1.0f;
    public float dashSpeed = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    public float dashCoolDownLeft;
    public float dashCoolDown = 1f;
    public int currentDashSec;

    private float currentDashTime;

    private void Start()
    {
        pFired = 0;
        currentDashTime = MaxDashTime;
        currentDashSec = (int)currentDashTime/1000;
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        dashCoolDownLeft -= Time.deltaTime;
       if(dashCoolDownLeft <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            dashCoolDownLeft = dashCoolDown;
            currentDashTime = 0.0f;
      
          
        }
        if (currentDashTime < MaxDashTime) 
        {
            //Dash shit no work :'(
            var mouse = Input.mousePosition;
            var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            transform.position += new Vector3(mouse.x-screenPoint.x, mouse.y-screenPoint.y,dashSpeed)*Time.deltaTime;
            currentDashTime += dashStoppingSpeed;
        }
        else
        {
            //moveDirection = Vector3.zero;
            transform.position += moveDirection * speed * Time.deltaTime;
            RotateChar();
        }
      
        
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
}