using UnityEngine;

public class Item
{
    string name;
    string description;
    int spriteID;

    public Item(string name, string description, int spriteID)
    {
        this.name = name;
        this.description = description;
        this.spriteID = spriteID;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }
    public int GetSpriteID()
    {
        return spriteID;
    }
}
