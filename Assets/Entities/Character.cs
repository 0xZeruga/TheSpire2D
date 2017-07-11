using Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Character : MonoBehaviour
{

    private Attack m_ChosenAttack;
    //private Movement m_PlayerMovement;
    public TimeManager m_Time;
    private Fire m_Proj;
    private Spin m_Spin;
    public Enemy m_Enemy;


    //Main Attributes
    public int Strength;
    public int Speed;
    public int Endurance;
    public int Intellect;
    public int Toughness;
    public int Luck;

    //Derived Attributes
    public int MeleeDMG;
    public int CarryCapacity;
    private float m_Health;
    public float HealthRegen;
    private float m_Stamina;
    private float StaminaRegen;
    private float m_Mana;
    private float ManaRegen;
    public int MagicDMG;
    public int SoulFragments;

    private int m_Level;
    private int m_Experience;
    private int m_Gold;

    public int Level
    {
        get { return m_Level; }
        set { m_Level = value; }
    }

    public int Experience
    {
        get { return m_Experience; }
        set { m_Experience = value; }
    }

    public int Gold
    {
        get { return m_Gold; }
        set { m_Gold = value; }
    }

    public float Health
    {
        get { return m_Health; }
        set { m_Health = value; }
    }
    public float Stamina
    {
        get { return m_Stamina; }
        set { m_Stamina = value; }
    }
    public float Mana
    {
        get { return m_Mana; }
        set { m_Mana = value; }
    }


    public int MAXHEALTH { get; set; }

    public int MAXSTAMINA { get; set; }

    public int MAXMANA { get; set; }

    public int MAXSOULTHIRST { get; set; }


    public string CharacterClassDescription = "";


    //Sets Default Attack to Spin
    //Activates movement script
    public void Start()
    {
        //m_ChosenAttack = new Spin();
        NewEnemy();
        //m_PlayerMovement = new Movement();

        CharacterClassDescription = "Poop";

        Strength = 5;
        Speed = 5;
        Endurance = 5;
        Intellect = 5;
        Toughness = 5;
        Luck = 5;

        m_Health = 100;
        m_Stamina = 75;
        m_Mana = 50;

        m_Level = 1;
        m_Experience = 0;
        m_Gold = 0;
        
        SoulFragments = 100;

    }
    public void Update()
    {
        CheckDeath();
        SwapAttack(m_Proj, m_Spin);
        CalcAtts();


        //Test Statsshift
        Health -= 1f;
        Stamina += 2f;

    }
    public void NewEnemy()
    {

        GameObject Enemy = new GameObject("Enemy"); // Make a new GO.
        Rigidbody eRB = Enemy.AddComponent<Rigidbody>(); // Add the rigidbody.
        eRB.mass = 5; // Set the GO's mass to 5 via the Rigidbody.


        eRB = Instantiate(eRB,
                                                                   this.transform.position,
                                                                   this.transform.rotation)
                        as Rigidbody;
    }

    //Swap between Range and Melee Attack with middle mouse button.

    public Attack SwapAttack(Fire p, Spin s)
    {
        m_Proj = p;
        m_Spin = s;
        if (Input.GetMouseButtonDown(2) && m_ChosenAttack == m_Spin)
        {
            m_ChosenAttack = m_Proj;
        }
        else if (Input.GetMouseButtonDown(2) && m_ChosenAttack == m_Proj)
        {
            m_ChosenAttack = m_Proj;
        }

        return m_ChosenAttack;
    }

    public void CalcAtts()
    {
        MeleeDMG = Strength;
        CarryCapacity = Strength * 2;
        Health = (Toughness * 2) + 5;
        HealthRegen = Toughness / 5;
        Stamina = Endurance * 2;
        StaminaRegen = Endurance / 2;
        Mana = Intellect * 2;
        ManaRegen = Intellect / 2;
        MagicDMG = Intellect;

    }

    //Updates Health, Stamina, Mana depending on regen accordingly.
    public void RegenStuff()
    {
        TimeSpan Reg = new TimeSpan(0, 0, 10);
        var T = m_Time.Now;
        if(T+Reg >= T)
        {
            Health += (int)HealthRegen;
            Stamina += (int)StaminaRegen;
            Mana += (int)ManaRegen;
            
        }

    }

    public void CheckDeath()
    {
        if(Health <= 0)
        {
            //PlayerDie and Respawn at start.
        }
    }

    //CheckColliders
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "SoulFragment")
        {
            Gold += 10;
        }
        else if(col.gameObject.name == "Enemy")
        {
            Health -= 1;
            //Add Pushback to player
        }
    }

    public void ShootAt(Enemy e)
    {
        //GameObject Fireball = (GameObject)Instantiate(FireballPrefab, this.transform.position, this.transform.rotation);
        //Fireball f = Fireball.GetComponent<Fireball>();
        //f.target = e.transform;
    }
}


    