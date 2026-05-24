using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //This script is responsible for managing the inventory, such as opening and closing the inventory UI

    //GameObject for the inventory UI, which will be set in the inspector
    public GameObject inventoryUI;  
    bool isInventoryOpen = false;

    public ItemSlot[] itemSlots;

    // Update is called once per frame
    void Update()
    {
        //Check if the I key is pressed and if the inventory is not open, if it is, open the inventory UI and set the isInventoryOpen variable to true, otherwise if the I key is pressed and the inventory is open, close the inventory UI and set the isInventoryOpen variable to false
        if (Input.GetKeyDown(KeyCode.I) && !isInventoryOpen)
        {
            Time.timeScale = 0;
            inventoryUI.SetActive(true);
            isInventoryOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInventoryOpen)
        {
            Time.timeScale = 1;
            inventoryUI.SetActive(false);
            isInventoryOpen = false;
        }
    }

    public void AddItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].isFull == false)
            {
                itemSlots[i].AddItem(item);
                return;
            }
        }
    }
}
