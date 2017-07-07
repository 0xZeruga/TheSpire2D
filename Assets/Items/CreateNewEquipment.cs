using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewEquipment : BaseEquipment
{

    private BaseEquipment newEquipment;
    private string[] itemNames = new string[] { "Common", "Great", "Amazing", "Insane" };
    // private string[] itemDescription = new string[] { "A new cool item", "A new not so cool item" };

    void Start()
    {
        CreateEquipment();
        Debug.Log(newEquipment.ItemName);
        Debug.Log(newEquipment.ItemDescription);
        Debug.Log(newEquipment.ItemID.ToString());
        Debug.Log(newEquipment.EquipmentType.ToString());
        Debug.Log(newEquipment.Strength.ToString());
        Debug.Log(newEquipment.Dexterity.ToString());

    }
    private void CreateEquipment()
    {
        newEquipment = new BaseEquipment();
        newEquipment.ItemName = itemNames[Random.Range(0, 3)] + " Item";
        newEquipment.ItemID = Random.Range(1, 101);

        newEquipment.ItemDescription = "This is a new Item";
        //itemDescription[Random.Range(0, itemDescription.Length)];
        newEquipment.Strength = Random.Range(1, 11);
        newEquipment.Dexterity = Random.Range(1, 11);
        newEquipment.Endurance = Random.Range(1, 11);
        newEquipment.Toughness = Random.Range(1, 11);
        newEquipment.Intelligence = Random.Range(1, 11);
        newEquipment.Luck = Random.Range(1, 11);
        ChooseItemType();

    }

    private void ChooseItemType()
    {
        int randomTemp = Random.Range(1, 11);
        if (randomTemp == 1)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
        }
        else if (randomTemp == 2)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.SHOULDERS;
        }
        else if (randomTemp == 3)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
        }
        else if (randomTemp == 4)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
        }
        else if (randomTemp == 5)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
        }
        else if (randomTemp == 6)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HANDS;
        }
        else if (randomTemp == 7)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.EARRING;
        }
        else if (randomTemp == 8)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.NECK;
        }
        else if (randomTemp == 9)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.RING;
        }
        else if (randomTemp == 10)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CAPE;
        }
    }
}
