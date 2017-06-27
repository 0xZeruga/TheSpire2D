using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPotion : BasePotion
{

    private BasePotion newPotion;
    //string that several names for potions

    // Use this for initialization
    void Start()
    {
        CreatePotion();
        Debug.Log(newPotion.ItemName);
        Debug.Log(newPotion.ItemDescription);
        Debug.Log(newPotion.ItemID.ToString());
        Debug.Log(newPotion.PotionType.ToString());


    }
    private void CreatePotion()
    {
        newPotion = new BasePotion();
        newPotion.ItemName = "Potion";
        newPotion.ItemDescription = "This is a potion";
        newPotion.ItemID = Random.Range(1, 101);
        ChoosePotionType();
    }

    private void ChoosePotionType()
    {
        int randomTemp = Random.Range(0, 10);
        if (randomTemp == 1)
        {
            newPotion.PotionType = BasePotion.PotionTypes.HEALTH;
        }
        else if (randomTemp == 2)
        {
            newPotion.PotionType = BasePotion.PotionTypes.ENERGY;
        }
        else if (randomTemp == 3)
        {
            newPotion.PotionType = BasePotion.PotionTypes.SPEED;
        }
        else if (randomTemp == 4)
        {
            newPotion.PotionType = BasePotion.PotionTypes.STRENGTH;
        }
        else if (randomTemp == 5)
        {
            newPotion.PotionType = BasePotion.PotionTypes.DEXTERITY;
        }
        else if (randomTemp == 6)
        {
            newPotion.PotionType = BasePotion.PotionTypes.ENDURANCE;
        }
        else if (randomTemp == 7)
        {
            newPotion.PotionType = BasePotion.PotionTypes.TOUGHNESS;
        }
        else if (randomTemp == 8)
        {
            newPotion.PotionType = BasePotion.PotionTypes.INTELLIGENCE;
        }
        else if (randomTemp == 9)
        {
            newPotion.PotionType = BasePotion.PotionTypes.CHARISMA;
        }

    }
}
