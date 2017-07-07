using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.SaveLoad
{
    public class Load : MonoBehaviour
    {

        public static void LoadAllInformation()
        {
            GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
            GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
            GameInformation.PlayerStrength = PlayerPrefs.GetInt("STRENGTH");
            GameInformation.PlayerDexterity = PlayerPrefs.GetInt("DEXTERITY");
            GameInformation.PlayerEndurance = PlayerPrefs.GetInt("ENDURANCE");
            GameInformation.PlayerToughness = PlayerPrefs.GetInt("TOUGHNESS");
            GameInformation.PlayerIntelligence = PlayerPrefs.GetInt("INTELLIGENCE");
            GameInformation.PlayerCharisma = PlayerPrefs.GetInt("CHARISMA");
            GameInformation.PlayerPerception = PlayerPrefs.GetInt("PERCEPTION");
            GameInformation.initiative = PlayerPrefs.GetInt("INITIATIVE");
            GameInformation.actionPoints = PlayerPrefs.GetInt("ACTIONPOINTS");
            GameInformation.health = PlayerPrefs.GetInt("HEALTH");
            GameInformation.mana = PlayerPrefs.GetInt("MANA");
            GameInformation.carryingCapacity = PlayerPrefs.GetInt("CARRYINGCAPACITY");
            GameInformation.baseAttackDamage = PlayerPrefs.GetInt("BASEATTACKDAMAGE");
            GameInformation.sight = PlayerPrefs.GetInt("SIGHT");
            GameInformation.dodgeChance = PlayerPrefs.GetInt("DODGECHANCE");
            GameInformation.persuasion = PlayerPrefs.GetInt("PERSUASION");

            //Add the rest
            if (PlayerPrefs.GetString("ITEM1") != null)
            {
                GameInformation.EquipmentOne = (BaseEquipment)PPSerialization.Load("ITEM1");
            }
        }
    }


}

