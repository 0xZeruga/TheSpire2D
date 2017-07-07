using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.SaveLoad
{

    public class GameInformation : MonoBehaviour
    {
        private void Awake()
        {
            
                DontDestroyOnLoad(transform.gameObject);
            
        }
        public static BaseEquipment EquipmentOne { get; set; }
        public static string PlayerName { get; set; }
        public static int PlayerLevel { get; set; }
        public static Character PlayerClass { get; set; }
        public static float PlayerStrength { get; set; }
        public static float PlayerDexterity { get; set; }
        public static float PlayerEndurance { get; set; }
        public static float PlayerToughness { get; set; }
        public static float PlayerIntelligence { get; set; }
        public static float PlayerCharisma { get; set; }
        public static float PlayerPerception { get; set; }

        public static float initiative { get; set; }
        public static float actionPoints { get; set; }
        public static float health { get; set; }
        public static float mana { get; set; }
        public static float carryingCapacity { get; set; }
        public static float baseAttackDamage { get; set; }
        public static float sight { get; set; }

        public static float dodgeChance { get; set; }
        public static float persuasion { get; set; }

    }
}
