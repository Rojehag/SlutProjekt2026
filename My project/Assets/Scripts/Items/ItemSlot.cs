using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //This script is responsible for the item slot in the inventory, which will display the item and its quantity, as well as handle adding items to the slot

    //Item that is currently in the slot, and a boolean to check if the slot is full or not
    public Item item;
    public bool isFull;

    //Text to display the quantity of the item in the slot, and an image to display the item's sprite
    [SerializeField] TMPro.TextMeshProUGUI quantityText;

    //Image to display the item's sprite
    [SerializeField] Image itemImage;


    //Function to add an item to the slot, which will set the item variable to the item passed in the parameter, set the isFull boolean to true, and update the itemImage and quantityText to display the item's sprite and quantity
    public void AddItem(Item item)
    {
        this.item = item;
        isFull = true;

        itemImage.gameObject.SetActive(true);
        itemImage.sprite = item.sprite;
        quantityText.text = item.quantity.ToString();
        quantityText.enabled = true;
    }
}
