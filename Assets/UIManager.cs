using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Character C;
    //public Move M;
    public int Money = 0;

    public Text HealthText;
    public Text StaminaText;
    public Text ManaText;
    public Text SoulThirstText;
    public Text LevelText;
    public Text ExperienceText;
    public Text NameText;
    public Text GoldText;
    //public Text DashCoolDown;


    //TODO: Create SoulFragements once unit is killed that can be collided with.
   


	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {

        HealthText.text = C.Health.ToString();
        StaminaText.text = C.Stamina.ToString();
        ManaText.text = C.Mana.ToString();
        SoulThirstText.text = C.SoulFragments.ToString();
        LevelText.text = C.Level.ToString();
        ExperienceText.text = C.Experience.ToString();
        NameText.text = C.name;
        GoldText.text = C.Gold.ToString();
       // DashCoolDown.text = M.currentDashSec.ToString();


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
