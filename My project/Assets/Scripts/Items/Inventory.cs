using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> inventory = new List<Item>();
    int coins = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheackIfInventoryFull()
    {
        if (inventory.Count == 20)
        {
            print("Inventory full");
            return true;
        }
        else
        {
            print("Inventory is not full");
            return false;
        }
    }

    void PickUpItem(Item item)
    {
        if(!CheackIfInventoryFull())
        {
            inventory.Add(item);
            print("Item added to inventory");
        }
        else 
        {
            print("Inventory was full Item not added");
        }
    }

    void DropItem()
    {
        //When Ui for inventory is made this will be used for the player to choose an item in the inventory to drop
        //It will then be removed from the inventory and instanciated in the world as a pickable item
    }
}
