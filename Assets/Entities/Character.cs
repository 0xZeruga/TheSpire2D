using Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Character : MonoBehaviour
{

    private Attack m_ChosenAttack;
    private Movement m_PlayerMovement;
    private Projectile m_Proj;
    private Spin m_Spin;
    public TimeManager m_Time;


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
    public int Health;
    public float HealthRegen;
    public int Stamina;
    private float StaminaRegen;
    public int Mana;
    private float ManaRegen;
    public int MagicDMG;


    public string CharacterClassDescription = "";


    //Sets Default Attack to Spin
    //Activates movement script
    public void Start()
    {
        m_ChosenAttack = new Spin();
        //m_PlayerMovement = new Movement();

        CharacterClassDescription = "Poop";

        Strength = 5;
        Speed = 5;
        Endurance = 5;
        Intellect = 5;
        Toughness = 5;
        Luck = 5;

        


    }
    public void Update()
    {
        CheckDeath();
        SwapAttack(m_Proj, m_Spin);
        CalcAtts();
    }

    //Swap between Range and Melee Attack with middle mouse button.

    public Attack SwapAttack(Projectile p, Spin s)
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
}


    