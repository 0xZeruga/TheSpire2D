using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

   // private Character Char;
    public float Speed;
    public Vector2 pPos;    

	// Use this for initialization
	void Start () {

        Speed = 10;
        pPos = transform.position;
    }

    public Vector2 NewPos()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.position = (movement * Speed);
       
        return pPos;
    }
    // Update is called once per frame
    void FixedUpdate () {
        //CheckKeyInput();
        //RotateChar();
        //Move();
        NewPos();
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
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
    private void CheckKeyInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Check KeyBoards Presses
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                if (vKey == KeyCode.W)
                {
                   // Char.transform.position.x = -1f;
                }
                if (vKey == KeyCode.A)
                {
                    movement = new Vector2(0f, -2f);
                    transform.position = (movement * Speed);
                }
                if (vKey == KeyCode.S)
                {

                }
                if (vKey == KeyCode.D)
                {
                    
                }
                if (vKey == KeyCode.Space)
                {
                    //Dash
                }
                //your code here

            }
        }
    }
    public void Move()
    {
        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position = move * Speed * Time.deltaTime;

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //transform.position = (movement * Speed);
    }

   
}
