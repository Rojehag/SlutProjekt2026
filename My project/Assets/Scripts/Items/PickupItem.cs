using UnityEngine;

public class PickupItem : MonoBehaviour
{
    //This script is responsible for picking up items in the game world, which will add the item to the player's inventory and destroy the item in the game world
    [SerializeField] Item item;

    //Reference to the InventoryManager script to add the item to the inventory when the player picks it up
    InventoryManager inventoryManager;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    //Function to check if the player collides with the item, if it does, it calls the AddItem function of the InventoryManager script to add the item to the inventory, and then destroys the item in the game world
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventoryManager.AddItem(item);
            Destroy(gameObject);
        }
    }
}
