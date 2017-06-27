using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{

    private Character Mage = new Character();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.Label(Mage.CharacterClassDescription);

        GUILayout.Label(Mage.Strength.ToString());
        GUILayout.Label(Mage.Endurance.ToString());
        GUILayout.Label(Mage.Toughness.ToString());
        GUILayout.Label(Mage.Luck.ToString());
        GUILayout.Label(Mage.Speed.ToString());
        GUILayout.Label(Mage.Intellect.ToString());
    }
}