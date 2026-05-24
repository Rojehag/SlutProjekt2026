using UnityEngine;


public class Item: ScriptableObject
{
    //This is the base class for all items it contains the basic stats that all items have and then the wepon and consumable classes will inherit from this and add their own stats
    public string name;
    public string description;
    public Sprite sprite;
    public int quantity;

}
