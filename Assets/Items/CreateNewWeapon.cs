using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : BaseWeapon
{

    private BaseWeapon newWeapon;
    //private string[] weaponNames = new String[6] {"Weapon of Greatness", ""}


    void Start()
    {
        CreateWeapon();
        Debug.Log(newWeapon.ItemName);
        Debug.Log(newWeapon.ItemDescription);
        Debug.Log(newWeapon.ItemID.ToString());
        Debug.Log(newWeapon.WeaponType.ToString());
        Debug.Log(newWeapon.Strength.ToString());
        Debug.Log(newWeapon.Dexterity.ToString());
    }

    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();
        newWeapon.ItemName = "W" + Random.Range(1, 101);
        newWeapon.ItemDescription = "This is a new weapon.";
        newWeapon.ItemID = Random.Range(1, 101);

        newWeapon.Strength = Random.Range(1, 11);
        newWeapon.Dexterity = Random.Range(1, 11);
        newWeapon.Endurance = Random.Range(1, 11);
        newWeapon.Toughness = Random.Range(1, 11);
        newWeapon.Intelligence = Random.Range(1, 11);
        newWeapon.Luck = Random.Range(1, 11);
        
        //assign name to weapon
        //create weapon description
        //weapon id
        //state
        //choose type of weapon
        //spell effect id

        ChooseWeaponType();
        newWeapon.SpellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        int randomTemp = Random.Range(1, 8);
        if (randomTemp == 1)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
        }
        else if (randomTemp == 2)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.STAFF;
        }
        else if (randomTemp == 3)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.AXE;
        }
        else if (randomTemp == 4)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
        }
        else if (randomTemp == 5)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.BOW;
        }
        else if (randomTemp == 6)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.POLEARM;
        }
        else if (randomTemp == 7)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
        }



    }
}
