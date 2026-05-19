using UnityEngine;

public class Wepons : Item
{
    int damage;
    float timeBetweenAttacks;
    float criticalChance;


    public Wepons(string name, int damage,  string description, float timeBetweenAttacks, float criticalChance, int spriteID) : base(name, description, spriteID)
    {
        this.damage = damage;
        this.timeBetweenAttacks = timeBetweenAttacks;
        this.criticalChance = criticalChance;
    }

    public int GetDamage()
    {
        return damage;
    }
    public float GetTimeBetweenAttacks()
    {
        return timeBetweenAttacks;
    }
    public float GetCriticalChance()
    {
        return criticalChance;
    }
}
