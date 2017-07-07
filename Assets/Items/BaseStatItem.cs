using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseStatItem : BaseItem
{

    private int strength;
    private int dexterity;
    private int endurance;
    private int toughness;
    private int intelligence;
    private int luck;

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }
    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }
    public int Toughness
    {
        get { return toughness; }
        set { toughness = value; }
    }
    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }
    public int Luck
    {
        get { return luck; }
        set { luck = value; }
    }


}
