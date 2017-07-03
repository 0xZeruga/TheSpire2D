using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {


    public Character C;
    public int Money = 0;

    //TODO: Create SoulFragements once unit is killed that can be collided with.
    public int SoulFragments = 100;


	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseHealth(float Damage)
    {
        C.Health -= Damage;
        if(C.Health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(1);
    }
}
