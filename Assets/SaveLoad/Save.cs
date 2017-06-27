using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.SaveLoad
{
    public class Save : MonoBehaviour
    {


        public static void SaveAllInformation()
        {
            PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
            PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);


            PlayerPrefs.SetFloat("STRENGTH", GameInformation.PlayerStrength);
            PlayerPrefs.SetFloat("DEXTERITY", GameInformation.PlayerDexterity);
            PlayerPrefs.SetFloat("ENDURANCE", GameInformation.PlayerEndurance);
            PlayerPrefs.SetFloat("TOUGHNESS", GameInformation.PlayerToughness);
            PlayerPrefs.SetFloat("INTELLIGENCE", GameInformation.PlayerIntelligence);
            PlayerPrefs.SetFloat("CHARISMA", GameInformation.PlayerCharisma);
            PlayerPrefs.SetFloat("PERCEPTION", GameInformation.PlayerPerception);


            PlayerPrefs.SetFloat("INITIATIVE", GameInformation.initiative);
            PlayerPrefs.SetFloat("ACTIONPOINTS", GameInformation.actionPoints);
            PlayerPrefs.SetFloat("HEALTH", GameInformation.health);
            PlayerPrefs.SetFloat("MANA", GameInformation.mana);
            PlayerPrefs.SetFloat("CARRYINGCAPACITY", GameInformation.carryingCapacity);
            PlayerPrefs.SetFloat("BASEATTACKDAMAGE", GameInformation.baseAttackDamage);
            PlayerPrefs.SetFloat("SIGHT", GameInformation.sight);
            PlayerPrefs.SetFloat("DODGECHANCE", GameInformation.dodgeChance);
            PlayerPrefs.SetFloat("PERSUASION", GameInformation.persuasion);


            //Add the rest
            if (GameInformation.EquipmentOne != null)
            {
                PPSerialization.Save("ITEM1", GameInformation.EquipmentOne);
            }
            Debug.Log("SAVED ALL INFO");
        }
    }
}
  