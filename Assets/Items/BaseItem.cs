using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BaseItem : MonoBehaviour
{

    private string itemName;
    private string itemDescription;
    private int itemID;
    private int itemWeight;
    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPON,
        SCROLL,
        POTION,
        CHEST

    }

    private ItemTypes itemType;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public string ItemDescription
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
    public int ItemWeight
    {
        get { return itemWeight; }
        set { itemWeight = value; }
    }

    public ItemTypes ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
